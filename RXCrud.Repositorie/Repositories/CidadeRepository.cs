using System.Linq;
using RXCrud.Data.Common;
using RXCrud.Data.Context;
using RXCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RXCrud.Domain.Interfaces.Data;
using System.Runtime.Intrinsics.Arm;

namespace RXCrud.Data.Repositories
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(RXCrudContext context) : base(context)
        {
        }

        public Cidade PesquisarPorDescricao(string descricao)
            => _context.Set<Cidade>().Where(u => u.Descricao.ToUpper().Equals(descricao.ToUpper())).AsNoTracking().FirstOrDefault();           
       
    }
}