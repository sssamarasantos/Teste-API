using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;

namespace Teste.API.Data.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly TesteDbContext _testeDbContext;

        public CompraRepository(TesteDbContext testeDbContext)
        {
            _testeDbContext = testeDbContext;
        }

        public async Task Create(Compra compra)
        {
            await _testeDbContext.AddAsync(compra);
        }

        public async Task<Compra> Read(int id)
        {
            var readBuy= await _testeDbContext.Compra.FindAsync(id);
            return readBuy;
        }

        public async Task Save()
        {
            await _testeDbContext.SaveChangesAsync();
        }

        public async Task<List<Compra>> Search()
        {
            var searchBuy = await _testeDbContext.Compra.ToListAsync();
            return searchBuy;
        }
    }
}
