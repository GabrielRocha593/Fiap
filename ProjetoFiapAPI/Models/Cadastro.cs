using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Models;

public class Cadastro
{
    [Key]
    [Required]
    public int Id { get; protected set; }
    [Required]
    public string Nome { get; set; } = "";
    public string? Email { get; set; } = "";
    public string? Telefone { get; set; } = "";
    public string? Endereco { get; set; } = "";
    public string? Complemento { get; set; } = "";
    public string? Bairro { get; set; } = "";
    public string? Municipio { get; set; } = "";
    public string? UF { get; set; } = "";
    public string? CEP { get; set; } = "";

    public virtual ICollection<Pedido> pedido { get; set; }
}
