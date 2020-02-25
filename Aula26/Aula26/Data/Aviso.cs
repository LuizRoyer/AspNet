using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula26.Data
{
    [Table("Avisos")]
    public class Aviso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Hora { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [StringLength(255)]
        public string Mensagem { get; set; }
    }
}
