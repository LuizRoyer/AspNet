using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escolas.Models
{
    public class Estudante
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o Nome do Estudante")]
        public string Nome { get; set; }
        public DateTime DataMatricula { get; set; }
        public ICollection<Matricula> ListaMatriculas { get; set; }
    }
}
