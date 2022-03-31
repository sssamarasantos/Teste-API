using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.API.Business.Repositories;
using Teste.API.Models;
using Teste.API.VOs;

namespace Teste.API.Data.Repositories
{
    public class CompraItemRepository : ICompraItemRepository
    {
        private readonly TesteDbContext _testeDbContext;

        public CompraItemRepository(TesteDbContext testeDbContext)
        {
            _testeDbContext = testeDbContext;
        }

        public async Task Create(CompraItem compraItem)
        {
            await _testeDbContext.AddAsync(compraItem);
        }

        public async Task<CompraItem> Read(int id)
        {
            var itemBuy = await _testeDbContext.CompraItem.FindAsync(id);
            return itemBuy;
        }

        public async Task Save()
        {
            await _testeDbContext.SaveChangesAsync();
        }

        public async Task<List<CompraItem>> Search()
        {
            var buyItems = await _testeDbContext.CompraItem.ToListAsync();
            return buyItems;
        }

        public async Task<ClienteCompraVO> BuscarComprasPorCliente(int clienteId)
        {
            List<ListaCompras> listasCompras = new List<ListaCompras>();

            var idsCompras = await _testeDbContext.Compra.Where(x => x.IdCliente == clienteId).Select(s => s.Id).ToListAsync();

            foreach (var idCompra in idsCompras)
            {
                var compra = await _testeDbContext.CompraItem.Include(i => i.Produto).Where(x => x.IdCompra == idCompra).ToListAsync();

                List<CompraUnit> listaComprasUnit = new List<CompraUnit>();
                ListaCompras listaCompras = new ListaCompras();

                foreach (var item in compra)
                {
                    CompraUnit compras = new CompraUnit
                    {
                        Produto = item.Produto.Nome,
                        Preco = item.Produto.Preco,
                        Quantidade = item.Quantidade,
                        Valor = item.Produto.Preco * item.Quantidade
                    };

                    listaComprasUnit.Add(compras);

                    listaCompras.IdCompra = item.IdCompra;
                }

                listaCompras.Compra = listaComprasUnit;
                listaCompras.TotalCompra = listaComprasUnit.Sum(x => x.Valor);

                listasCompras.Add(listaCompras);
            }

            ClienteCompraVO clienteCompraVO = new ClienteCompraVO
            {
                IdCliente = clienteId,
                ListaCompras = listasCompras
            };

            return clienteCompraVO;
        }

        public async Task<ProdutoCompraVO> BuscarComprasPorProduto(int produtoId)
        {
            var produto = await _testeDbContext.Produto.FirstOrDefaultAsync(x => x.Id == produtoId);
            var compras = await _testeDbContext.CompraItem.Where(x => x.IdProduto == produtoId).ToListAsync();

            ProdutoCompraVO produtoCompraVO = new ProdutoCompraVO
            {
                Produto = produto.Nome,
                TotalCompras = compras.Sum(s => s.Quantidade),
                PrecoTotal = compras.Sum(s => s.Quantidade) * produto.Preco
            };

            return produtoCompraVO;
        }

        public async Task<List<ProdutoCompraVO>> BuscarComprasDeProdutos()
        {
            var produtos = await _testeDbContext.Produto.ToListAsync();

            List<ProdutoCompraVO> listaProdutoCompraVO = new List<ProdutoCompraVO>();

            foreach(var produto in produtos)
            {
                var compras = await _testeDbContext.CompraItem.Where(x => x.IdProduto == produto.Id).ToListAsync();

                ProdutoCompraVO produtoCompraVO = new ProdutoCompraVO
                {
                    Produto = produto.Nome,
                    TotalCompras = compras.Sum(s => s.Quantidade),
                    PrecoTotal = compras.Sum(s => s.Quantidade) * produto.Preco
                };

                listaProdutoCompraVO.Add(produtoCompraVO);
            }

            return listaProdutoCompraVO;
        }
    }
}
