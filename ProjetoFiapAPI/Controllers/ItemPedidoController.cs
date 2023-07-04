using AutoMapper;
using ProjetoFiapAPI.Data;
using ProjetoFiapAPI.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFiapAPI.Data.Dtos.Cadastro;
using ProjetoFiapAPI.Data.Dtos.Pedido;
using ProjetoFiapAPI.Data.Dtos.Itempedido;

namespace ProjetoFiapAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemPedidoController : ControllerBase
    {
        private SiteContext _context;
        private IMapper _mapper;

        public ItemPedidoController(SiteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaItemPedido([FromBody] CreateCadastroDto itemPedidoDto)
        {
            ItemPedido itemPedido = _mapper.Map<ItemPedido>(itemPedidoDto);
            _context.ItemPedido.Add(itemPedido);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaItemPedidoPorId), new { Id = itemPedido.Id }, itemPedido);
        }

        [HttpGet]
        public IEnumerable<ReadCadastroDto> RecuperaitemPedido()
        {
            return _mapper.Map<List<ReadCadastroDto>>(_context.ItemPedido);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaItemPedidoPorId(int id)
        {
            ItemPedido itemPedido = _context.ItemPedido.FirstOrDefault(itemPedido => itemPedido.Id == id);
            if (itemPedido != null)
            {
                ReadItempedidoDto itemPedidoDto = _mapper.Map<ReadItempedidoDto>(itemPedido);

                return Ok(itemPedidoDto);
            }
            return NotFound();
        }
    }
}
