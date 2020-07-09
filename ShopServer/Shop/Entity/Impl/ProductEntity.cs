using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.Good;

namespace Shop.Entity.Impl
{
    public class ProductEntity: IProductEntity
    {

        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Product> Products;

        public ProductEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Products = context.Products;
        }

        public async Task AddNewProduct(Product product)
        {
            await Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Products.AsQueryable().Include(p => p.Kind).Include(p => p.ProductSuppliers).ThenInclude(ps => ps.Supplier).ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await Products.AsQueryable().Include(p => p.ProductSuppliers).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
