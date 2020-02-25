using System;
using System.ComponentModel.DataAnnotations;

namespace Crud_Aluno.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obrigatoria")]
        [StringLength(50, MinimumLength =5,ErrorMessage ="Nome invalido")]
        [Display(Name ="Informe o Nome do Aluno")]
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Texto { get; set; }
    }
}
