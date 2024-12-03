using Microsoft.AspNetCore.Mvc;
using ApiAS.Models;
using ApiAS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorsController : ControllerBase
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorsController(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Get()
        {
            var fornecedores = await _repository.GetAllAsync();
            return Ok(fornecedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> Get(int id)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null)
                return NotFound();
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Fornecedor fornecedor)
        {
            await _repository.AddAsync(fornecedor);
            return CreatedAtAction(nameof(Get), new { id = fornecedor.Id }, fornecedor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Fornecedor fornecedorAtualizado)
        {
            Fornecedor? fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null)
                return NotFound();

            fornecedor.Nome = fornecedorAtualizado.Nome;
            fornecedor.Cnpj = fornecedorAtualizado.Cnpj;
            fornecedor.Telefone = fornecedorAtualizado.Telefone;
            fornecedor.Email = fornecedorAtualizado.Email;
            fornecedor.Endereco = fornecedorAtualizado.Endereco;

            await _repository.UpdateAsync(fornecedor);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var fornecedor = await _repository.GetByIdAsync(id);
            if (fornecedor == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}