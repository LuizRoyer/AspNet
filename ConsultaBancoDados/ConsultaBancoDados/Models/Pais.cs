using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsultaBancoDados.Models
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Nomedo Pais")]
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
