using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoFiapAPI.Data;
using ProjetoFiapAPI.Data.Dtos.Cadastro;
using ProjetoFiapAPI.Models;

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
        public IActionResult AdicionaCinema([FromBody] CreateCadastroDto CadastroDto)
        {
            Cadastro cadastro = _mapper.Map<Cadastro>(CadastroDto);
            _context.Cadastro.Add(cadastro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCadastroPorId), new { Id = cadastro.Id }, CadastroDto);
        }

        [HttpGet]
        public IEnumerable<ReadCadastroDto> RecuperaCadastro([FromQuery] int? pedidoId = null)
        {
            if(pedidoId == null)
            {
                return _mapper.Map<List<ReadCadastroDto>>(_context.Cadastro.ToList());                        
            }
            //return _mapper.Map<List<ReadCadastroDto>>(_context.Cadastro.FromSqlRaw($"SELECT Id, Nome, EnderecoId FROM cinemas where cinemas.EnderecoId = {pedidoId}").ToList());
            return _mapper.Map<List<ReadCadastroDto>>(_context.Cadastro.Where(cadastro => cadastro.Pedido.Any(pedido => pedido.Id == pedidoId)).ToList());
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

    }
}
