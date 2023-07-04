using ProjetoFiapAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Data.Dtos.Pedido;

public class CreatePedidoDto
{
    public int? CadastroId { get; set; }
    public virtual ICollection<ItemPedido>? ItemPedido { get; set; }
}
