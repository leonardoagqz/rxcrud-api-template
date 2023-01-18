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
using System;
using System.Collections.Generic;
using System.Linq;

namespace RXCrud.NUnitTest.Services
{
    public class CidadeServiceTest
    {
        private Cidade _cidade;
        private IMapper _mapper;
        private ICidadeService _cidadeService;
        private Mock<ICidadeRepository> _mockCidadeRepository;

        public CidadeServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _mockCidadeRepository = new Mock<ICidadeRepository>();
            _cidadeService = new CidadeService(_mapper, _mockCidadeRepository.Object);
            _cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
        }

        [Test]
        public void CriarTest()
            => Assert.DoesNotThrow(() => _cidadeService.Criar(new CidadeDto(Guid.NewGuid(), "Cidade Teste 1")));

        [Test]
        public void CriarErroTest()
        {
            _mockCidadeRepository.Setup(r => r.PesquisarPorDescricao("Cidade Teste")).Returns(_cidade);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _cidadeService.Criar(new CidadeDto(Guid.NewGuid(), "Cidade Teste")))
                .Message.Equals("A cidade informada já está cadastrada."));
        }

        [Test]
        public void AtualizarTest()
            => Assert.DoesNotThrow(() => _cidadeService.Atualizar(new CidadeDto(Guid.NewGuid(), "Cidade Teste 2")));

        [Test]
        public void AtualizarErroTest()
        {
            _mockCidadeRepository.Setup(r => r.PesquisarPorDescricao("Cidade Teste")).Returns(_cidade);
            Assert.IsTrue(Assert.Throws<RXCrudException>(() => _cidadeService.Atualizar(new CidadeDto(Guid.NewGuid(), "Cidade Teste")))
                .Message.Equals("A cidade informada já está cadastrada."));
        }

        [Test]
        public void RemoverTest()
            => Assert.DoesNotThrow(() => _cidadeService.Remover(new CidadeDto(Guid.NewGuid(), "Cidade Teste")));

        [Test]
        public void ObterTodosTest()
        {
            IList<Cidade> cidadesList = new List<Cidade>();
            cidadesList.Add(_cidade);

            _mockCidadeRepository.Setup(r => r.ObterTodos()).Returns(cidadesList.AsQueryable());
            Assert.IsNotNull(_cidadeService.ObterTodos());
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            _mockCidadeRepository.Setup(r => r.PesquisarPorId(_cidade.Id)).Returns(_cidade);
            Assert.IsNotNull(_cidadeService.PesquisarPorId(_cidade.Id));
        }
    }
}