using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DTO.Good;
using Shop.Models.ORM.Good;

namespace Shop.Service
{
    public interface IProductService
    {
        public Task<bool> AddNewProduct(ProductDTO productDto);

        public Task<List<Product>> GetAllProducts();

        public Task<bool> UpdateProduct(ProductDTO productDto);

        public Task<bool> DeleteProduct(ProductDTO productDto);

        public Task<bool> UpdateProduct(Product product);

    }
}
