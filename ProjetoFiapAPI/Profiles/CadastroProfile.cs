using AutoMapper;
using FilmesApi.Models;
using SiteAPI.Data.Dtos.Cadastro;

namespace FilmesApi.Profiles
{
    public class CadastroProfile : Profile
    {
        public CadastroProfile()
        {
            CreateMap<CreateCadastroDto, Cadastro>();
            CreateMap<Cadastro, ReadCadastroDto>();               
            CreateMap<UpdateCadastroDto, Cadastro>();
        }
    }
}
