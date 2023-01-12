using Moq;
using System;
using AutoMapper;
using System.Linq;
using NUnit.Framework;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.NUnitTest.Common;
using RXCrud.Service.Services;
using System.Collections.Generic;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;

namespace RXCrud.NUnitTest.Services
{
    public class EstadoServiceTest
    {
        private IMapper _mapper;
        private Estado _estado;
        private IEstadoService _estadoService;
        private Mock<IEstadoRepository> _mockEstadoRepository;

        public EstadoServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _mockEstadoRepository = new Mock<IEstadoRepository>();
            _estadoService = new EstadoService(_mapper, _mockEstadoRepository.Object);
            _estado = new Estado("Estado Teste", "Descrição Teste");
        }

        [Test]
        public void CriarTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorUf("Estado Teste")).Returns(_estado);
            Assert.DoesNotThrow(() => _estadoService.Criar(new EstadoDto("Estado Teste", "Descrição Teste")));
        }
                
        
        [Test]
        public void AtualizarTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorUf("Estado Teste")).Returns(_estado);
            Assert.DoesNotThrow(() => _estadoService.Atualizar(new EstadoDto("Estado Teste Atualizar", "Descrição Teste")));
        }
        

        [Test]
        public void RemoverTest()
            => Assert.DoesNotThrow(() => _estadoService.Remover(new EstadoDto("Estado Teste Atualizar", "Descrição Teste")));

        [Test]
        public void ObterTodosTest()
        {
            IList<Estado> estadosList = new List<Estado>();
            estadosList.Add(_estado);

            _mockEstadoRepository.Setup(r => r.ObterTodos()).Returns(estadosList.AsQueryable());
            Assert.IsNotNull(_estadoService.ObterTodos());
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorId(_estado.Id)).Returns(_estado);
            Assert.IsNotNull(_estadoService.PesquisarPorId(_estado.Id));
        }      

    }
}