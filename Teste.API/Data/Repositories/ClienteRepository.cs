using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;

namespace Teste.API.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly TesteDbContext _testeDbContext;

        public ClienteRepository(TesteDbContext testeDbContext)
        {
            _testeDbContext = testeDbContext;
        }

        public async Task Create(Cliente cliente)
        {
            await _testeDbContext.AddAsync(cliente);
        }

        public async Task Delete(int id)
        {
            var readClient = await _testeDbContext.Cliente.FindAsync(id);
            _testeDbContext.Remove(readClient);
        }

        public async Task<Cliente> Read(int id)
        {
            var readClient = await _testeDbContext.Cliente.FindAsync(id);
            return readClient;
        }

        public async Task Save()
        {
            await _testeDbContext.SaveChangesAsync();
        }

        public async Task<List<Cliente>> Search()
        {
            var searchClient = await _testeDbContext.Cliente.ToListAsync();
            return searchClient;
        }

        public async Task Update(Cliente cliente)
        {
            var clientUpdated = await _testeDbContext.Cliente.FindAsync(cliente.Id);
            clientUpdated.Nome = cliente.Nome;
            clientUpdated.Telefone = cliente.Telefone;
            clientUpdated.Endereco = cliente.Endereco;

            _testeDbContext.Update(clientUpdated);
        }
    }
}
