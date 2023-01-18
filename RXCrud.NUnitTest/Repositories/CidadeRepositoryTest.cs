using NUnit.Framework;
using RXCrud.Data.Repositories;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.NUnitTest.Common;
using System;
using System.Collections.Generic;

namespace RXCrud.NUnitTest.Repositories
{
    public class CidadeRepositoryTest
    {
        private IEstadoRepository _estadoRepository;
        private ICidadeRepository _cidadeRepository;

        public CidadeRepositoryTest()
        {
            _estadoRepository = new EstadoRepository(Utilitarios.GetContext());
            _cidadeRepository = new CidadeRepository(Utilitarios.GetContext());
        }

        [Test]
        public void CriarTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Cidade cidade = new Cidade(estado.Id, "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPorId(cidade.Id));
        }

        [Test]
        public void AtualizarTest()
        {

            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Cidade cidade = new Cidade(estado.Id, "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            cidade.Descricao = "Cidade Atualizada";
            _cidadeRepository.Atualizar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPor(x => x.Descricao.Equals("Cidade Atualizada")));
        }

        [Test]
        public void RemoverTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Cidade cidade = new Cidade(estado.Id, "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            _cidadeRepository.Remover(cidade);

            Assert.IsNull(_cidadeRepository.PesquisarPorId(cidade.Id));
        }

        [Test]
        public void RemoverListaTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Cidade cidade = new Cidade(estado.Id, "Cidade Teste Create");
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
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Cidade cidade = new Cidade(estado.Id, "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPor(x => x.Id.Equals(cidade.Id)));
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Cidade cidade = new Cidade(estado.Id, "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.PesquisarPorId(cidade.Id));
        }

        [Test]
        public void ObterTodosPorTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Cidade cidade = new Cidade(estado.Id, "Cidade Teste Create");
            _cidadeRepository.Criar(cidade);

            Assert.IsNotNull(_cidadeRepository.ObterTodosPor(x => x.Id.Equals(cidade.Id)));
        }
    }
}