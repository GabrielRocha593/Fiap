using AutoMapper;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using ProjetoFiapAPI.Data;
using ProjetoFiapAPI.Data.Dtos.Cadastro;
using ProjetoFiapAPI.Models;
using System.Text.RegularExpressions;

namespace ProjetoFiapAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private SiteContext _context;
        private IMapper _mapper;

        public CadastroController(SiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaCadastro([FromBody] CreateCadastroDto CadastroDto)
        {
            Cadastro cadastro = _mapper.Map<Cadastro>(CadastroDto);
            _context.Cadastro.Add(cadastro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCadastroPorId), new { Id = cadastro.Id }, CadastroDto);
        }

        [HttpGet]
        public IEnumerable<ReadCadastroDto> RecuperaCadastro([FromQuery] int? cadastroId = null)
        {
            if(cadastroId == null)
            {
                return _mapper.Map<List<ReadCadastroDto>>(_context.Cadastro.ToList());                        
            }
            //return _mapper.Map<List<ReadCadastroDto>>(_context.Cadastro.FromSqlRaw($"SELECT Id, Nome, EnderecoId FROM cinemas where cinemas.EnderecoId = {pedidoId}").ToList());
            return _mapper.Map<List<ReadCadastroDto>>(_context.Cadastro.Where(cadastro => cadastro.Id == cadastroId).ToList()); ;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCadastroPorId(int id)
        {
            Cadastro cadastro = _context.Cadastro.FirstOrDefault(cadastro => cadastro.Id == id);
            if (cadastro != null)
            {
                ReadCadastroDto cadastroDto = _mapper.Map<ReadCadastroDto>(cadastro);
                return Ok(cadastroDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCadastro(int id, [FromBody] UpdateCadastroDto cadastroDto)
        {
            Cadastro cadastro = _context.Cadastro.FirstOrDefault(cadastro => cadastro.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }
            _mapper.Map(cadastroDto, cadastro);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCadastro(int id)
        {
            Cadastro cadastro = _context.Cadastro.FirstOrDefault(cadastro => cadastro.Id == id);
            if (cadastro == null)
            {
                return NotFound();
            }
            _context.Remove(cadastro);
            _context.SaveChanges();
            return NoContent();
        }

        public string UploadImage([FromBody] string base64Image)
        {

            // Gera um nome randomico para imagem
            var fileName = Guid.NewGuid().ToString() + ".jpg";

            // Limpa o hash enviado
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");

            // Gera um array de Bytes
            byte[] imageBytes = Convert.FromBase64String(data);

            // Define o BLOB no qual a imagem será armazenada
            var blobClient = new BlobClient("https://gabrielsalomao01.blob.core.windows.net", "fotos", fileName);

            // Envia a imagem
            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            // Retorna a URL da imagem
            return blobClient.Uri.AbsoluteUri;
        }

    }
}
