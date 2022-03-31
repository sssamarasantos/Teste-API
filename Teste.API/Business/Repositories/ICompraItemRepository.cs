using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.API.Models;
using Teste.API.VOs;

namespace Teste.API.Business.Repositories
{
    public interface ICompraItemRepository
    {
        Task<List<CompraItem>> Search();
        Task<CompraItem> Read(int id);
        Task Create(CompraItem compraItem);
        Task Save();
        Task<ClienteCompraVO> BuscarComprasPorCliente(int clienteId);
        Task<ProdutoCompraVO> BuscarComprasPorProduto(int produtoId);
        Task<List<ProdutoCompraVO>> BuscarComprasDeProdutos();
    }
}
