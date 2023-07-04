using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Models
{
    public class ItemPedido
    {
        [Key]
        [Required]
        public int Id { get; protected set; }
        [Required]
        public int PedidoID { get; set; }
        public virtual Pedido Pedido { get; set; }

        [Required]
        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; private set; }

        [Required]
        public decimal PrecoUnitario { get; private set; }

    }
}
