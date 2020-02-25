namespace FluentApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int quantidade { get; set; }
        public double Preco { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
