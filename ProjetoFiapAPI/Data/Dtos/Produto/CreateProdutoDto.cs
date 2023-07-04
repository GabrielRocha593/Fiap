using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Data.Dtos.Produto
{
    public class CreateProdutoDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo de Preco é obrigatório.")]
        public decimal preco { get; set; }
    }
}
