using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;

namespace Teste.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoCompraController : ControllerBase
    {
        private readonly ICompraItemRepository _compraItemRepository;

        public ProdutoCompraController(ICompraItemRepository compraItemRepository)
        {
            _compraItemRepository = compraItemRepository;
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> BuscarComprasPorProduto(int produtoId)
        {
            var searchProducts = await _compraItemRepository.BuscarComprasPorProduto(produtoId);
            return Ok(searchProducts);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarComprasDeProdutos()
        {
            var searchProducts = await _compraItemRepository.BuscarComprasDeProdutos();
            return Ok(searchProducts);
        }
    }
}
