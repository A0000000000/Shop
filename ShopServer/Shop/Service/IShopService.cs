using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DTO.Good;
using Shop.Models.DTO.Shop;
using Shop.Models.ORM.User;

namespace Shop.Service
{
    public interface IShopService
    {
        public Task<List<ProductDTO>> GetAllProducts();

        public Task<bool> SubmitOrder(Customer customer, List<ItemDTO> orders);

    }
}
