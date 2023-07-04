using AutoMapper;
using ProjetoFiapAPI.Models;
using ProjetoFiapAPI.Data.Dtos.Produto;

namespace ProjetoFiapAPI.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<Produto, ReadProdutoDto>();
            CreateMap<UpdateProdutoDto, Produto>();
        }
    }
}
