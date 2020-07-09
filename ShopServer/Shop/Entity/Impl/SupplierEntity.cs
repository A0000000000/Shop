using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.Good;

namespace Shop.Entity.Impl
{
    public class SupplierEntity: ISupplierEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Supplier> Suppliers;

        public SupplierEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Suppliers = context.Suppliers;
        }


        public async Task<Supplier> GetSupplierByName(string name)
        {
            return await Suppliers.Where(s => s.Name == name).Include(s => s.ProductSuppliers).ThenInclude(ps => ps.Product).FirstOrDefaultAsync();
        }

        public async Task AddNewSupplier(Supplier supplier)
        {
            await Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }
    }
}
