using System.Collections.Generic;

namespace FluentApi.Models
{
    public class Cliente
    {
        public Cliente()
        {
            ListaPedidos = new List<Pedido>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }

        public virtual List<Pedido> ListaPedidos { get; set; }
    }
}
