using System.Linq;
using RXCrud.Data.Common;
using RXCrud.Data.Context;
using RXCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RXCrud.Domain.Interfaces.Data;

namespace RXCrud.Data.Repositories
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(RXCrudContext context) : base(context)
        {
        }

        public Estado PesquisarPorUf(string uf)
            => _context.Set<Estado>().Where(u => u.Uf.ToUpper().Equals(uf.ToUpper())).AsNoTracking().FirstOrDefault();

    }
}