using System.ComponentModel.DataAnnotations;

namespace ProjetoFiapAPI.Data.Dtos.Cadastro
{
    public class CreateCadastroDto
    {
        [Required(ErrorMessage = "O campo de Nome é obrigatório.")]
        public string Nome { get; set; } = "";

        public string Email { get; set; } = "";

        public string Telefone { get; set; } = "";

        public string Endereco { get; set; } = "";

        public string Complemento { get; set; } = "";

        public string Bairro { get; set; } = "";

        public string Municipio { get; set; } = "";

        public string UF { get; set; } = "";

        public string CEP { get; set; } = "";

        public string? Imagem { get; set; } = "";
    }
}
