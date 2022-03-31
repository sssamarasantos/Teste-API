using System.ComponentModel.DataAnnotations;

namespace Teste.API.Models
{
    public class Produto
    {
        public Produto(int id, string nome, double preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public double Preco { get; set; }
    }
}
