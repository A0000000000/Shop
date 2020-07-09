using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Good;

namespace Shop.Entity
{
    public interface IProductEntity
    {
        public Task AddNewProduct(Product product);

        public Task<List<Product>> GetAllProducts();

        public Task<Product> GetProduct(int id);

        public Task UpdateProduct(Product product);

        public Task DeleteProduct(Product product);

    }
}
