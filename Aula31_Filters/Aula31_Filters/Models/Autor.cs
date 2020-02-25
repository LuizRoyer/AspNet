using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula31_Filters.Models
{
    [Table("Autores")]
    public class Autor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(30)]
        public string Twitter { get; set; }
    }
}
