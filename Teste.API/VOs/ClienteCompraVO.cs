using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teste.API.Models;

namespace Teste.API.VOs
{
    public class ClienteCompraVO
    {
        public int IdCliente { get; set; }
        public List<ListaCompras> ListaCompras { get; set; }
    }

    public class ListaCompras
    {
        public int IdCompra { get; set; }
        public List<CompraUnit> Compra { get; set; }
        public double TotalCompra { get; set; }
    }

    public class CompraUnit
    {
        public string Produto { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
