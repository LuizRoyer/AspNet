using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_BancoDadosAula2.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obrigatoria")]
        [StringLength(50, MinimumLength =5,ErrorMessage ="Nome invalido")]
        [Display(Name ="Informe o Nome do Cliente")]
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
