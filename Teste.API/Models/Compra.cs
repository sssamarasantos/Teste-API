using System.ComponentModel.DataAnnotations;

namespace Teste.API.Models
{
    public class Compra
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
