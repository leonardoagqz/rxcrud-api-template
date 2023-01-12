using System;
using NUnit.Framework;
using RXCrud.Domain.Entities;
using RXCrud.NUnitTest.Common;
using RXCrud.Data.Repositories;
using System.Collections.Generic;
using RXCrud.Domain.Interfaces.Data;

namespace RXCrud.NUnitTest.Repositories
{
    public class CidadeRepositoryTest
    {
        private ICidadeRepository _cidadeRepository;

        public CidadeRepositoryTest()
            => _cidadeRepository = new CidadeRepository(Utilitarios.GetContext());

        [Test]
        public void CriarTest()
        {
            Cidade cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPorId(cidade.Id));
        }

        [Test]
        public void AtualizarTest()
        {
            Cidade cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            cidade.Descricao = "Cidade Atualizada";
            _cidadeRepository.Atualizar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPor(x => x.Descricao.Equals("Cidade Atualizada")));
        }

        [Test]
        public void RemoverTest()
        {
            Cidade cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            _cidadeRepository.Remover(cidade);

            Assert.IsNull(_cidadeRepository.PesquisarPorId(cidade.Id));
        }

        [Test]
        public void RemoverListaTest()
        {
            Cidade cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            IList<Cidade> cidades = new List<Cidade>();
            cidades.Add(cidade);

            _cidadeRepository.RemoverLista(cidades);

            Assert.IsNull(_cidadeRepository.PesquisarPorId(cidade.Id));
        }

        [Test]
        public void ObterTodosTest()
            => Assert.IsNotNull(_cidadeRepository.ObterTodos());

        [Test]
        public void PesquisarPorTest()
        {
            Cidade cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPor(x => x.Id.Equals(cidade.Id)));
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            Cidade cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPorId(cidade.Id));
        }

        [Test]
        public void ObterTodosPorTest()
        {
            Cidade cidade = new Cidade(Guid.NewGuid(), "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.ObterTodosPor(x => x.Id.Equals(cidade.Id)));
        }      

      
    }
}