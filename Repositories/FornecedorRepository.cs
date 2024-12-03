using ApiAS.Data;
using ApiAS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiAS.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly AppDbContext _context;

        public FornecedorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fornecedor>> GetAllAsync()
        {
            return await _context.Fornecedors.ToListAsync();
        }

        public async Task<Fornecedor> GetByIdAsync(int id)
        {
            return await _context.Fornecedors.FindAsync(id);
        }

        public async Task AddAsync(Fornecedor fornecedor)
        {
            await _context.Fornecedors.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fornecedor fornecedor)
        {
            _context.Fornecedors.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fornecedor = await _context.Fornecedors.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedors.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}