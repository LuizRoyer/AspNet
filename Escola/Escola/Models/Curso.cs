using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escolas.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Informe o nome do Curso")]
        public string Titulo { get; set; }
        public int Creditos { get; set; }
        public ICollection<Matricula> ListaMatriculas{ get; set; }
    }
}
