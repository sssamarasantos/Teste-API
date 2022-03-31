using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;

namespace Teste.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompraItemController : ControllerBase
    {
        private readonly ICompraItemRepository _compraItemRepository;

        public CompraItemController(ICompraItemRepository compraItemRepository)
        {
            _compraItemRepository = compraItemRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var searchClients = await _compraItemRepository.Read(id);
            return Ok(searchClients);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var searchClients = await _compraItemRepository.Search();
            return Ok(searchClients);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompraItem cliente)
        {
            await _compraItemRepository.Create(cliente);
            await _compraItemRepository.Save();

            return Created("", cliente);
        }
    }
}
