using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Common;

namespace RXCrud.Domain.Interfaces.Data
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        Cidade PesquisarPorDescricao(string descricao);
    }
}