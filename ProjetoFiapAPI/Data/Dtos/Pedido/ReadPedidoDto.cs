using ProjetoFiapAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Data.Dtos.Pedido
{
    public class ReadPedidoDto
    {
        public int CadastroId { get; set; }
        public ICollection<ItemPedido>? ItemPedido { get; set; }
    }
}
