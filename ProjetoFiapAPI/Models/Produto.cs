
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; protected set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        public decimal Preco { get; private set; }

        public virtual ICollection<ItemPedido> ItemPedido { get; set; }

    }
}
