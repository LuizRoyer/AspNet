using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CoreEF.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Sexo { get; set; }
        [Required]
        [StringLength(150)]
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(150)]
        public string Foto { get; set; }
        [Required]
        [StringLength(100)]
        public string Texto { get; set; }

        public Socio TipoSocio { get; set; }
    }
}
