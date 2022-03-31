using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;

namespace Teste.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteCompraController : ControllerBase
    {
        private readonly ICompraItemRepository _compraItemRepository;

        public ClienteCompraController(ICompraItemRepository compraItemRepository)
        {
            _compraItemRepository = compraItemRepository;
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> BuscarComprasPorCliente(int clienteId)
        {
            var searchClients = await _compraItemRepository.BuscarComprasPorCliente(clienteId);
            return Ok(searchClients);
        }
    }
}
