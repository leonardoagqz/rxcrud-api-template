using NUnit.Framework;
using RXCrud.Data.Repositories;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using RXCrud.NUnitTest.Common;
using System.Collections.Generic;

namespace RXCrud.NUnitTest.Repositories
{
    public class EstadoRepositoryTest
    {
        private IEstadoRepository _estadoRepository;

        public EstadoRepositoryTest()
            => _estadoRepository = new EstadoRepository(Utilitarios.GetContext());

        [Test]
        public void CriarTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Assert.IsNotNull(_estadoRepository.PesquisarPorId(estado.Id));
        }

        [Test]
        public void AtualizarTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            estado.Uf = "UF Atualizado";
            _estadoRepository.Atualizar(estado);

            Assert.IsNotNull(_estadoRepository.PesquisarPor(x => x.Uf.Equals("UF Atualizado")));
        }

        [Test]
        public void RemoverTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            _estadoRepository.Remover(estado);

            Assert.IsNull(_estadoRepository.PesquisarPorId(estado.Id));
        }

        [Test]
        public void RemoverListaTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            IList<Estado> estados = new List<Estado>();
            estados.Add(estado);

            _estadoRepository.RemoverLista(estados);

            Assert.IsNull(_estadoRepository.PesquisarPorId(estado.Id));
        }

        [Test]
        public void ObterTodosTest()
            => Assert.IsNotNull(_estadoRepository.ObterTodos());

        [Test]
        public void PesquisarPorTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Assert.IsNotNull(_estadoRepository.PesquisarPor(x => x.Id.Equals(estado.Id)));
        }

        [Test]
        public void PesquisarPorIdTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Assert.IsNotNull(_estadoRepository.PesquisarPorId(estado.Id));
        }

        [Test]
        public void ObterTodosPorTest()
        {
            Estado estado = new Estado("UF Teste Create", "Descrição Teste Create");
            _estadoRepository.Criar(estado);

            Assert.IsNotNull(_estadoRepository.ObterTodosPor(x => x.Id.Equals(estado.Id)));
        }
    }
}