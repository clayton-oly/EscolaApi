using EscolaApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/alunos")]
public class AlunosController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AlunosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/alunos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
    {
        return await _context.Alunos.ToListAsync();
    }

    // GET: api/alunos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno == null)
        {
            return NotFound();
        }

        return aluno;
    }

    // POST: api/alunos
    [HttpPost]
    public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
    }

    // PUT: api/alunos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAluno(int id, Aluno aluno)
    {
        if (id != aluno.Id)
        {
            return BadRequest();
        }

        _context.Entry(aluno).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlunoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/alunos/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Aluno>> DeleteAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound();
        }

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    private bool AlunoExists(int id)
    {
        return _context.Alunos.Any(e => e.Id == id);
    }
}
