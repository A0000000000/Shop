using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.User;

namespace Shop.Entity.Impl
{
    public class AdministratorEntity: IAdministratorEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Administrator> Administrators;

        public AdministratorEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Administrators = context.Administrators;
        }


        public async Task<Administrator> GetAdministratorByUsername(string username)
        {
            return await (from administrators in Administrators where administrators.Username == username select administrators).FirstOrDefaultAsync();
        }

        public async Task AddNewAdministrator(Administrator administrator)
        {
            await Administrators.AddAsync(administrator);
            await _context.SaveChangesAsync();
        }
    }
}
