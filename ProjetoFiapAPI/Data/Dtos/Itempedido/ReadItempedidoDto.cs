using ProjetoFiapAPI.Data.Dtos.Pedido;
using ProjetoFiapAPI.Data.Dtos.Produto;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Data.Dtos.Itempedido
{
    public class ReadItempedidoDto
    {
        public ReadPedidoDto Pedido { get; set; }
        public ReadProdutoDto Produto { get; set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
    }
}
