using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.Utils;

namespace Shop.Entity.Impl
{
    public class ProductSupplierEntity: IProductSupplierEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<ProductSupplier> ProductSuppliers;

        public ProductSupplierEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            ProductSuppliers = context.ProductSuppliers;
        }

        public async Task AddNewProductSupplier(ProductSupplier ps)
        {
            await ProductSuppliers.AddAsync(ps);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductSupplier(ProductSupplier ps)
        {
            ProductSuppliers.Remove(ps);
            await _context.SaveChangesAsync();
        }
    }
}
