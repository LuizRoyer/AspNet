using System.ComponentModel.DataAnnotations;

namespace MVC_CoreEF.Models
{
    public class Socio
    {
        [Key]
        public int TipoSocioId { get; set; }
        [Required]
        public int Duracao { get; set; }
        [Required]
        public int TaxaDesconto { get; set; }
        [Required]
        [StringLength(100)]
        public string Descricao { get; set; }
    }
}
