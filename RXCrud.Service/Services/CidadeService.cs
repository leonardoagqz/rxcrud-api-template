﻿using System;
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
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeService(IMapper mapper, ICidadeRepository cidadeRepository)
        {
            _mapper = mapper;
            _cidadeRepository = cidadeRepository;
        }

        public void Criar(CidadeDto cidadeDto)
        {
            CidadeJaCadastrada(cidadeDto);

            _cidadeRepository.Criar(_mapper.Map<Cidade>(cidadeDto));           
        }

        public void Atualizar(CidadeDto cidadeDto)
        {
            CidadeJaCadastrada(cidadeDto);
            
            _cidadeRepository.Atualizar(_mapper.Map<Cidade>(cidadeDto));
        }

        private void CidadeJaCadastrada(CidadeDto cidadeDto)
        {
            Cidade cidade = _cidadeRepository.PesquisarPorDescricao(cidadeDto.Descricao);
            if ((cidade != null) && (cidade.Id != cidadeDto.Id))
            {
                throw new RXCrudException("A Cidade informada já está sendo utilizada.");
            }
        }

        public void Remover(CidadeDto cidadeDto)
            => _cidadeRepository.Remover(_mapper.Map<Cidade>(cidadeDto));

        public IQueryable<CidadeDto> ObterTodos()
            => _cidadeRepository.ObterTodos().ProjectTo<CidadeDto>(_mapper.ConfigurationProvider);

        public CidadeDto PesquisarPorId(Guid id)
           => _mapper.Map<CidadeDto>(_cidadeRepository.PesquisarPorId(id));   
        
    }
}