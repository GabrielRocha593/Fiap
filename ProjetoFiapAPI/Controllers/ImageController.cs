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
    public class ImagemController : ControllerBase
    {
        private SiteContext _context;
        private IMapper _mapper;

        public ImagemController(SiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost("{CadastroId}")]
        public IActionResult AdicionaFoto(string CadastroId, [FromBody] string base64Image)
        {
            var fileName = CadastroId + ".jpg";

            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64Image, "");


            byte[] imageBytes = Convert.FromBase64String(data);

            var blobClient = new BlobClient("DefaultEndpointsProtocol=https;AccountName=gabrielsalomao01;AccountKey=zhmlAjEcWYBZ6dfj5728YyVzfsIjV/cuehFrrAuxmmFtUbSHgmjsK6JaxAZAiPve1EiwW4gVRNvI+AStT4NkVw==;EndpointSuffix=core.windows.net", "fotos", fileName);


            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream);
            }

            return Ok(blobClient.Uri.AbsoluteUri);
        }

    }
}
