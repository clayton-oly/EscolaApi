using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EscolaApi
{
    [Table("Alunos")] // Especifica o nome da tabela no banco de dados

    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Range(0, 120, ErrorMessage = "A idade deve estar entre 0 e 120 anos.")]
        public int Idade { get; set; }

        [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10.")]
        public decimal NotaPrimeiroSemestre { get; set; }

        [Range(0, 10, ErrorMessage = "A nota deve estar entre 0 e 10.")]
        public decimal NotaSegundoSemestre { get; set; }

        public string NomeProfessor { get; set; }

        public int NumeroSala { get; set; }
    }
}

