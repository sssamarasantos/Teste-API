using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.API.Models;

namespace Teste.API.Business.Repositories
{
    public interface ICompraRepository
    {
        Task<List<Compra>> Search();
        Task<Compra> Read(int id);
        Task Create(Compra compra);
        Task Save();
    }
}
