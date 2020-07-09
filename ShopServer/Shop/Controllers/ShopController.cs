using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Shop.Filter;
using Shop.Models.DTO.Good;
using Shop.Models.DTO.Shop;
using Shop.Models.ORM.User;
using Shop.Service;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ShopController: ControllerBase
    {
        private readonly IShopService Service;
        private readonly ICustomerService CustomerService;

        public ShopController(IShopService service, ICustomerService customerService)
        {
            Service = service;
            CustomerService = customerService;
        }

        [HttpPost]
        public async Task<List<ProductDTO>> GetAllProduct()
        {
            return await Service.GetAllProducts();
        }

        [HttpPost]
        [LoginFilter]
        public async Task<Dictionary<string, object>> SubmitOrder(List<ItemDTO> orders)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            string username = Request.Headers["username"];
            Customer customer = await CustomerService.GetCustomerByUsername(username);
            if (customer != null)
            {
                bool ret = await Service.SubmitOrder(customer, orders);
                if (ret)
                {
                    res["status"] = "success";
                    res["message"] = "提交成功!";
                }
                else
                {
                    res["status"] = "failed";
                    res["message"] = "服务器错误, 请稍后再试!";
                }
            }
            else
            {
                res["status"] = "failed";
                res["message"] = "登录状态异常, 请重新登录!";
            }
            return res;
        }

    }
}
