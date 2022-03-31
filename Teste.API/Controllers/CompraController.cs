using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;

namespace Teste.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _compraRepository;

        public CompraController(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var searchClients = await _compraRepository.Read(id);
            return Ok(searchClients);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var searchClients = await _compraRepository.Search();
            return Ok(searchClients);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Compra cliente)
        {
            await _compraRepository.Create(cliente);
            await _compraRepository.Save();

            return Created("", cliente);
        }
    }
}
