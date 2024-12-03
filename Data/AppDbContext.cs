using Microsoft.EntityFrameworkCore;
using ApiAS.Models;

namespace ApiAS.Data
{
    public class AppDbContext : DbContext
    {
        public required DbSet<Pedido> Pedidos { get; set; }
        public required DbSet<Fornecedor> Fornecedors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=pedidos.db");
        }
    }
}