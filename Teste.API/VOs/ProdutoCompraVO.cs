using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.API.VOs
{
    public class ProdutoCompraVO
    {
        public string Produto { get; set; }
        public int TotalCompras { get; set; }
        public double PrecoTotal { get; set; }
    }
}
