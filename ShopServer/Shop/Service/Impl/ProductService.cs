using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Entity;
using Shop.Models.DTO.Good;
using Shop.Models.ORM.Good;
using Shop.Models.ORM.Utils;

namespace Shop.Service.Impl
{
    public class ProductService: IProductService
    {
        private readonly IProductEntity Entity;
        private readonly IKindEntity KindEntity;
        private readonly ISupplierEntity SupplierEntity;
        private readonly IProductSupplierEntity ProductSupplierEntity;

        public ProductService(IProductEntity entity, IKindEntity kindEntity, ISupplierEntity supplierEntity, IProductSupplierEntity productSupplierEntity)
        {
            Entity = entity;
            KindEntity = kindEntity;
            SupplierEntity = supplierEntity;
            ProductSupplierEntity = productSupplierEntity;
        }


        public async Task<bool> AddNewProduct(ProductDTO productDto)
        {
            try
            { 
                Supplier supplier = await SupplierEntity.GetSupplierByName(productDto.Supplier);
                if (supplier == null)
                {
                    supplier = new Supplier()
                    {
                        Name = productDto.Supplier
                    };
                    await SupplierEntity.AddNewSupplier(supplier);
                }
                Kind kind = await KindEntity.GetKindByName(productDto.Kind);
                if (kind == null)
                {
                    kind = new Kind()
                    {
                        Name = productDto.Kind
                    };
                    await KindEntity.AddNewKind(kind);
                }
                Product product = new Product()
                {
                    Name = productDto.Name,
                    Price = Convert.ToDecimal(productDto.Price),
                    Repository = Convert.ToUInt32(productDto.Repository),
                    Message = productDto.Message,
                    Kind = kind
                };
                await Entity.AddNewProduct(product);
                ProductSupplier ps = new ProductSupplier()
                {
                    Product = product,
                    Supplier = supplier
                }; 
                await ProductSupplierEntity.AddNewProductSupplier(ps);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await Entity.GetAllProducts();
        }

        public async Task<bool> UpdateProduct(ProductDTO productDto)
        {
            try
            {
                Product product = await Entity.GetProduct(productDto.Id);
                product.Name = productDto.Name;
                product.Message = productDto.Message;
                product.Price = Convert.ToDecimal(productDto.Price);
                product.Repository = Convert.ToUInt32(productDto.Repository);
                await Entity.UpdateProduct(product);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProduct(ProductDTO productDto)
        {
            try
            {
                Product product = await Entity.GetProduct(productDto.Id);
                await Entity.DeleteProduct(product);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            try
            {
                await Entity.UpdateProduct(product);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
