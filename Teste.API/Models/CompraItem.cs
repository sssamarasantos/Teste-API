using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.API.Models
{
    public class CompraItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdCompra { get; set; }
        public virtual Compra Compra { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdProduto { get; set; }
        public virtual Produto Produto { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantidade { get; set; }
    }
}
