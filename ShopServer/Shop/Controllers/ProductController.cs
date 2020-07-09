using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Filter;
using Shop.Models.DTO.Good;
using Shop.Models.ORM.Good;
using Shop.Models.ORM.Utils;
using Shop.Service;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class ProductController: ControllerBase
    {
        private readonly IProductService Service;

        public ProductController(IProductService service)
        {
            Service = service;
        }


        [HttpPost]
        [LoginFilter(true)]
        public async Task<Dictionary<string, object>> AddNewProduct(ProductDTO product)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            bool ret = await Service.AddNewProduct(product);
            if (ret)
            {
                res["status"] = "success";
                res["message"] = "添加成功!";
            }
            else
            {
                res["status"] = "failed";
                res["message"] = "添加失败!";
            }
            return res;
        }

        [HttpPost]
        [LoginFilter(true)]
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            List<Product> products = await Service.GetAllProducts();
            List<ProductDTO> res = products.ConvertAll(p =>
            {
                StringBuilder sb = new StringBuilder();
                foreach (ProductSupplier supplier in p.ProductSuppliers)
                {
                    sb.Append($"{supplier.Supplier.Name} ");
                }
                return new ProductDTO()
                {
                    Id = p.Id,
                    Kind = p.Kind.Name,
                    Message = p.Message,
                    Name = p.Name,
                    Price = p.Price.ToString(),
                    Repository = p.Repository.ToString(),
                    Supplier = sb.ToString().Trim()
                };
            });
            return res;
        }

        [HttpPost]
        [LoginFilter(true)]
        public async Task<Dictionary<string, object>> UpdateProduct(ProductDTO product)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            bool ret = await Service.UpdateProduct(product);
            if (ret)
            {
                res["status"] = "success";
                res["message"] = "更新成功!";
            }
            else
            {
                res["status"] = "failed";
                res["message"] = "服务器错误, 请稍后再试!";
            }
            return res;
        }

        [HttpPost]
        [LoginFilter(true)]
        public async Task<Dictionary<string, object>> DeleteProduct(ProductDTO product)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            bool ret = await Service.DeleteProduct(product);
            if (ret)
            {
                res["status"] = "success";
                res["message"] = "删除成功!";
            }
            else
            {
                res["status"] = "failed";
                res["message"] = "服务器错误, 请稍后再试!";
            }
            return res;
        }

    }
}
