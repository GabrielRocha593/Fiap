using AutoMapper;
using ProjetoFiapAPI.Data;
using ProjetoFiapAPI.Data.Dtos;
using ProjetoFiapAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjetoFiapAPI.Data.Dtos.Pedido;

namespace ProjetoFiapAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{

    private SiteContext _context;
    private IMapper _mapper;

    public PedidoController(SiteContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaPedido(
        [FromBody] CreatePedidoDto pedidoDto)
    {
        Pedido pedido = _mapper.Map<Pedido>(pedidoDto);
        _context.Pedido.Add(pedido);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaPedidoPorId), new { id = pedido.Id }, pedido);
    }

    [HttpGet]
    public IEnumerable<ReadPedidoDto> RecuperaPedido([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
            return _mapper.Map<List<ReadPedidoDto>>(_context.Pedido.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPedidoPorId(int id)
    {
        var pedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido == null) return NotFound();
        var pedidoDto = _mapper.Map<ReadPedidoDto>(pedido);
        return Ok(pedidoDto);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPedido(int id)
    {
        var pedido = _context.Pedido.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido == null) return NotFound();
        _context.Remove(pedido);
        _context.SaveChanges();
        return NoContent();
    }
}
        