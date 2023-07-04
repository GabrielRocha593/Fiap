using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Data.Dtos.Produto
{
    public class UpdateProdutoDto
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
