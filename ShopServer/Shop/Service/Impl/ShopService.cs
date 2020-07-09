using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Entity;
using Shop.Filter;
using Shop.Models.DTO.Good;
using Shop.Models.DTO.Shop;
using Shop.Models.ORM.Good;
using Shop.Models.ORM.Shop;
using Shop.Models.ORM.User;

namespace Shop.Service.Impl
{
    public class ShopService: IShopService
    {
        private readonly IProductService ProductService;
        private readonly IOrderEntity OrderEntity;
        private readonly IItemEntity ItemEntity;

        public ShopService(IProductService productService, IOrderEntity orderEntity, IItemEntity itemEntity)
        {
            ProductService = productService;
            OrderEntity = orderEntity;
            ItemEntity = itemEntity;
        }

        [HttpPost]
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            List<Product> products = await ProductService.GetAllProducts();
            List<ProductDTO> res = products.ConvertAll(p => new ProductDTO()
            {
                Id = p.Id,
                Kind = p.Kind.Name,
                Message = p.Message,
                Name = p.Name,
                Price = p.Price.ToString(),
                Repository = p.Repository.ToString()
            });
            return res;
        }

        public async Task<bool> SubmitOrder(Customer customer, List<ItemDTO> orders)
        {
            try
            {
                List<Item> items = new List<Item>();
                Order order = new Order
                {
                    Customer = customer, CreateTime = DateTime.Now, Guid = Guid.NewGuid(), Items = items
                };
                List<Product> products = await ProductService.GetAllProducts();
                List<Product> update = new List<Product>();
                foreach (Product product in products)
                {
                    foreach (ItemDTO itemDto in orders)
                    {
                        if (itemDto.Id == product.Id)
                        {
                            if (product.Repository < Convert.ToUInt32(itemDto.Count))
                            {
                                return false;
                            }
                            update.Add(product);
                        }
                    }
                }
                foreach (Product product in update)
                {
                    foreach (ItemDTO itemDto in orders)
                    {
                        if (itemDto.Id == product.Id)
                        {
                            items.Add(new Item()
                            {
                                Count = Convert.ToInt32(itemDto.Count),
                                Order = order,
                                Product = product
                            });
                            product.Repository -= Convert.ToUInt32(itemDto.Count);
                        }
                    }
                }
                foreach (Product product in update)
                {
                    await ProductService.UpdateProduct(product);
                }
                await OrderEntity.AddOrder(order);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
