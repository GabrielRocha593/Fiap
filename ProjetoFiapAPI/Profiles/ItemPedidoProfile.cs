using AutoMapper;
using FilmesApi.Models;
using SiteAPI.Data.Dtos.Itempedido;

namespace FilmesApi.Profiles
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile()
        {
            CreateMap<CreateItemPedidoDto, ItemPedido>();
            CreateMap<ItemPedido, ReadItempedidoDto>()
                .ForMember(ItemPedidoDto => ItemPedidoDto.Pedido,
                    opt => opt.MapFrom(itemPedido => itemPedido.Pedido))
                .ForMember(ItemPedidoDto => ItemPedidoDto.Produto,
                    opt => opt.MapFrom(itemPedido => itemPedido.Produto));
        }
    }
}
