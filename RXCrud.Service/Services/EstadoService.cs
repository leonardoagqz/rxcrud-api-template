using System;
using AutoMapper;
using System.Linq;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Data;
using AutoMapper.QueryableExtensions;
using RXCrud.Domain.Interfaces.Services;

namespace RXCrud.Service.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(IMapper mapper, IEstadoRepository estadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = estadoRepository;
        }

        public void Criar(EstadoDto estadoDto)
        {
            UfJaCadastrada(estadoDto);

            _estadoRepository.Criar(_mapper.Map<Estado>(estadoDto));           
        }

        public void Atualizar(EstadoDto estadoDto)
        {
            UfJaCadastrada(estadoDto);
            
            _estadoRepository.Atualizar(_mapper.Map<Estado>(estadoDto));
        }

        private void UfJaCadastrada(EstadoDto estadoDto)
        {
            Estado estado = _estadoRepository.PesquisarPorUf(estadoDto.Uf);
            if ((estado != null) && (estado.Id != estadoDto.Id))
            {
                throw new RXCrudException("A uf informada já está sendo utilizada.");
            }
        }
        
        public void Remover(EstadoDto estadoDto)
            => _estadoRepository.Remover(_mapper.Map<Estado>(estadoDto));

        public IQueryable<EstadoDto> ObterTodos()
            => _estadoRepository.ObterTodos().ProjectTo<EstadoDto>(_mapper.ConfigurationProvider);

        public EstadoDto PesquisarPorId(Guid id)
           => _mapper.Map<EstadoDto>(_estadoRepository.PesquisarPorId(id));      


    }
}