using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.Good;

namespace Shop.Entity.Impl
{
    public class KindEntity: IKindEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Kind> Kinds;

        public KindEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Kinds = context.Kinds;
        }


        public async Task<Kind> GetKindByName(string name)
        {
            return await Kinds.Where(k => k.Name == name).Include(k => k.Products).FirstOrDefaultAsync();
        }

        public async Task AddNewKind(Kind kind)
        {
            await Kinds.AddAsync(kind);
            await _context.SaveChangesAsync();
        }
    }
}
