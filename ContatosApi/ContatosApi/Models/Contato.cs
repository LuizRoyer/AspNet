using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContatosApi.Models
{
    [Table("Contatos")]
    public class Contato
    {[Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Nome é Obrigatorio")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Email é Obrigatorio")]
        [StringLength(150)]
        [EmailAddress(ErrorMessage ="Email Invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Telefone é Obrigatorio")]
        [StringLength(15)]
        public string Telefone { get; set; }
    }
}
