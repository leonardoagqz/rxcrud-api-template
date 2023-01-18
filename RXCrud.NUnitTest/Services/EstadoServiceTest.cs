using AutoMapper;
using Moq;
using NUnit.Framework;
using RXCrud.Domain.Dto;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Exception;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.Domain.Interfaces.Services;
using RXCrud.NUnitTest.Common;
using RXCrud.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace RXCrud.NUnitTest.Services
{
    public class EstadoServiceTest
    {
        private Estado _estado;
        private IMapper _mapper;
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
            => Assert.DoesNotThrow(() => _estadoService.Criar(new EstadoDto("CE", "Descrição Teste")));

        [Test]
        public void CriarErroTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorUf("Estado Teste")).Returns(_estado);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _estadoService.Criar(new EstadoDto("Estado Teste", "Descrição Teste")))
                .Message.Equals("A uf informada já está cadastrada."));
        }
              
        [Test]
        public void AtualizarTest()
            => Assert.DoesNotThrow(() => _estadoService.Atualizar(new EstadoDto("SP", "Descrição Teste")));        

        [Test]
        public void AtualizarErroTest()
        {
            _mockEstadoRepository.Setup(r => r.PesquisarPorUf("Estado Teste")).Returns(_estado);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _estadoService.Atualizar(new EstadoDto("Estado Teste", "Descrição Teste")))
                .Message.Equals("A uf informada já está cadastrada."));
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