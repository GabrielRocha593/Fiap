using AutoMapper;
using ProjetoFiapAPI.Models;
using ProjetoFiapAPI.Data.Dtos.Itempedido;

namespace ProjetoFiapAPI.Profiles
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
