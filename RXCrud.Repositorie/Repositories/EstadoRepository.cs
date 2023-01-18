using Microsoft.EntityFrameworkCore;
using RXCrud.Data.Common;
using RXCrud.Data.Context;
using RXCrud.Domain.Entities;
using RXCrud.Domain.Interfaces.Data;
using System.Linq;

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