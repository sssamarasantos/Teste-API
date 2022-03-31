using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.API.Models;

namespace Teste.API.Business.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> Search();
        Task<Cliente> Read(int id);
        Task Create(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);
        Task Save();
    }
}
