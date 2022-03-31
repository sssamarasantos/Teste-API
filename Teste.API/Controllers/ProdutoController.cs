using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;

namespace Teste.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var searchClients = await _produtoRepository.Read(id);
            return Ok(searchClients);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var searchClients = await _produtoRepository.Search();
            return Ok(searchClients);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            await _produtoRepository.Create(produto);
            await _produtoRepository.Save();

            return Created("", produto);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(Produto produto)
        {
            _produtoRepository.Update(produto);
            await _produtoRepository.Save();

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoRepository.Delete(id);
            await _produtoRepository.Save();

            return Ok();
        }
    }
}
