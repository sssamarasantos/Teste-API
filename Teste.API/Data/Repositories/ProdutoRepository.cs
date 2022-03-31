using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;

namespace Teste.API.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly TesteDbContext _testeDbContext;

        public ProdutoRepository(TesteDbContext testeDbContext)
        {
            _testeDbContext = testeDbContext;
        }

        public async Task Create(Produto produto)
        {
            await _testeDbContext.AddAsync(produto);
        }

        public async Task Delete(int id)
        {
            var readClient = await _testeDbContext.Produto.FindAsync(id);
            _testeDbContext.Remove(readClient);
        }

        public async Task<Produto> Read(int id)
        {
            var readProduct = await _testeDbContext.Produto.FindAsync(id);
            return readProduct;
        }

        public async Task Save()
        {
            await _testeDbContext.SaveChangesAsync();
        }

        public async Task<List<Produto>> Search()
        {
            var searchProduct = await _testeDbContext.Produto.ToListAsync();
            return searchProduct;
        }

        public async Task Update(Produto produto)
        {
            var productUpdated = await _testeDbContext.Produto.FindAsync(produto.Id);
            productUpdated.Nome = produto.Nome;
            productUpdated.Preco = produto.Preco;

            _testeDbContext.Update(produto);
        }
    }
}
