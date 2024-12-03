namespace ApiAS.Models
{
    public class Fornecedor
    {
        public int Id { get; set; } // Primary key, Auto-increment
        public required string Nome { get; set; }
        public required string Cnpj { get; set; }
        public required string Telefone { get; set; }
        public required string Email { get; set; }
        public required string Endereco { get; set; }
    }
}