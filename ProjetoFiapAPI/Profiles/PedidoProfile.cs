using AutoMapper;
using FilmesApi.Models;
using SiteAPI.Data.Dtos.Pedido;
using SiteAPI.Models;

namespace FilmesApi.Profiles;

public class PedidoProfile : Profile
{
	public PedidoProfile()
	{
		CreateMap<CreatePedidoDto, Pedido>();
        CreateMap<Pedido, ReadPedidoDto>()
            .ForMember(pedidoDto => pedidoDto.ItemPedido,
                    opt => opt.MapFrom(pedido => pedido.ItemPedido))
            .ForMember(pedidoDto => pedidoDto.CadastroId,
                    opt => opt.MapFrom(pedido => pedido.Cadastro));
}
}
