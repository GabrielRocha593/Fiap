using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Models
{
    public class Pedido
    {
        [Key]
        [Required]
        public int Id { get; protected set; }
        public int? CadastroId { get; set; }
        public virtual Cadastro Cadastro { get; set; }
        public virtual ICollection<ItemPedido> ItemPedido { get; set; }
    }
}
