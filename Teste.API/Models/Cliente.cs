using System.ComponentModel.DataAnnotations;

namespace Teste.API.Models
{
    public class Cliente
    {
        public Cliente(int id, string nome, string telefone, string endereco)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Endereco { get; set; }
    }
}
