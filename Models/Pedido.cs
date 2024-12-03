namespace ApiAS.Models
{
    public class Pedido
    {
        public int Id { get; set; } // Primary key, Auto-increment
        public required DateTime Data { get; set; }
        public required decimal ValorTotal { get; set; }
        public required string Status { get; set; }
        public required string Descricao { get; set; }
    }
}