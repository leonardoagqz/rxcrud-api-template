using AutoMapper;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;

namespace RXCrud.Service.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Estado, EstadoDto>()
                .ReverseMap();

            CreateMap<Cidade, CidadeDto>()
                .ReverseMap();

            CreateMap<Usuario, UsuarioDto>()
                .ReverseMap();
            
        }
    }
}