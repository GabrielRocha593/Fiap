using AutoMapper;
using ProjetoFiapAPI.Models;
using ProjetoFiapAPI.Data.Dtos.Cadastro;

namespace ProjetoFiapAPI.Profiles
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
