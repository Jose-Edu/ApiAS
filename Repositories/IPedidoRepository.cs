using ApiAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAS.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido> GetByIdAsync(int id);
        Task AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido cliente);
        Task DeleteAsync(int id);
    }
}