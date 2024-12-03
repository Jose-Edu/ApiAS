using Microsoft.AspNetCore.Mvc;
using ApiAS.Models;
using ApiAS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _repository;

        public PedidosController(IPedidoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> Get()
        {
            var pedidos = await _repository.GetAllAsync();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> Get(int id)
        {
            var pedido = await _repository.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Pedido pedido)
        {
            await _repository.AddAsync(pedido);
            return CreatedAtAction(nameof(Get), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Pedido pedidoAtualizado)
        {
            var pedido = await _repository.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();

            pedido.Data = pedidoAtualizado.Data;
            pedido.ValorTotal = pedidoAtualizado.ValorTotal;
            pedido.Status = pedidoAtualizado.Status;
            pedido.Descricao = pedidoAtualizado.Descricao;

            await _repository.UpdateAsync(pedido);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pedido = await _repository.GetByIdAsync(id);
            if (pedido == null)
                return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}