using Microsoft.EntityFrameworkCore;

namespace EscolaApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações específicas do modelo podem ser adicionadas aqui
            // Por exemplo, limitar o tamanho do campo Nome para 100 caracteres:
            // modelBuilder.Entity<Aluno>()
            //     .Property(a => a.Nome)
            //     .HasMaxLength(100);
        }
    }
}
