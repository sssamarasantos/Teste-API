using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.API.Models;
namespace Teste.API.Business.Repositories
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> Search();
        Task<Produto> Read(int id);
        Task Create(Produto produto);
        Task Update(Produto produto);
        Task Delete(int id);
        Task Save();
    }
}
