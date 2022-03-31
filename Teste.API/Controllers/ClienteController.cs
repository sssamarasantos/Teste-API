using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;

namespace Teste.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ICompraItemRepository _compraItemRepository;

        public ClienteController(IClienteRepository clienteRepository, ICompraItemRepository compraItemRepository)
        {
            _clienteRepository = clienteRepository;
            _compraItemRepository = compraItemRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var searchClients = await _clienteRepository.Read(id);
            return Ok(searchClients);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var searchClients = await _clienteRepository.Search();
            return Ok(searchClients);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cliente cliente)
        {
            await _clienteRepository.Create(cliente);
            await _clienteRepository.Save();

            return Created("", cliente);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Cliente cliente)
        {
            await _clienteRepository.Update(cliente);
            await _clienteRepository.Save();

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteRepository.Delete(id);
            await _clienteRepository.Save();

            return Ok();
        }
    }
}
