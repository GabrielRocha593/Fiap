using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Data.Dtos.Itempedido
{
    public class CreateItemPedidoDto
    {
        [Required(ErrorMessage = "O campo de Pedido é obrigatório.")]
        public int PedidoID { get; set; }
        [Required(ErrorMessage = "O campo de Produto é obrigatório.")]
        public int ProdutoID { get; set; }
        [Required(ErrorMessage = "O campo de Quantidade é obrigatório.")]
        public int Quantidade { get; private set; }
        [Required(ErrorMessage = "O campo de Preco Unitario é obrigatório.")]
        public decimal PrecoUnitario { get; private set; }
    }
}
