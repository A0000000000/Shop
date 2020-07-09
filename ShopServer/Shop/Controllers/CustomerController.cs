using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shop.Filter;
using Shop.Models.DTO.User;
using Shop.Models.ORM.User;
using Shop.Service;
using Shop.Service.Impl;
using Shop.Tools;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService Service;

        public CustomerController(ICustomerService service)
        {
            Service = service;
        }

        [HttpGet]
        public string Index()
        {
            return "Just for fun";
        }


        [HttpPost]
        public async Task<Dictionary<string, object>> Register(Customer customer)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            if (!ModelState.IsValid)
            {
                res["status"] = "failed";
                res["message"] = "参数不合法, 请检查参数!";
            }
            else
            {
                int statusCode = await Service.Register(customer);
                if (statusCode == 0)
                {
                    res["status"] = "success";
                    res["message"] = "注册成功!";
                }
                else if (statusCode == 1)
                {
                    res["status"] = "failed";
                    res["message"] = "用户名冲突, 请更换用户名!";
                }
                else
                {
                    res["status"] = "failed";
                    res["message"] = "服务器错误, 请稍后再试!";
                }
            }
            return res;
        }

        [HttpPost]
        public async Task<Dictionary<string, object>> Login(CustomerLoginDTO customerDTO)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            if (string.IsNullOrEmpty(customerDTO.Username) || string.IsNullOrEmpty(customerDTO.Password))
            {
                res["status"] = "failed";
                res["message"] = "用户名或密码不能为空!";
            }
            else
            {
                Customer customer = await Service.Login(customerDTO.Username, customerDTO.Password);
                if (customer == null)
                {
                    res["status"] = "failed";
                    res["message"] = "用户名或密码错误!";
                }
                else
                {
                    res["status"] = "success";
                    res["token"] = JWTTools.Encode(customer.Username, DateTime.Now.AddDays(1));
                }
            }
            return res;
        }

        [HttpPost]
        [LoginFilter]
        public async Task<Dictionary<string, object>> GetCustomerInfo()
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            string username = Request.Headers["username"];
            Customer customer = await Service.GetCustomerByUsername(username);
            if (customer == null)
            {
                res["status"] = "failed";
                res["message"] = "账户异常, 请重新登录!";
            }
            else
            {
                res["status"] = "success";
                res["id"] = customer.Id;
                res["username"] = customer.Username;
                res["birthday"] = customer.Birthday;
                res["email"] = customer.Email;
                res["phone"] = customer.Phone;
                res["createTime"] = customer.CreateTime;
            }
            return res;
        }

        [HttpPost]
        [LoginFilter]
        public async Task<Dictionary<string, object>> UpdateCustomerInfo(Customer update)
        {

            Dictionary<string, object> res = new Dictionary<string, object>();
            string username = Request.Headers["username"];
            Customer customer = await Service.GetCustomerByUsername(username);
            if (customer == null)
            {
                res["status"] = "failed";
                res["message"] = "账户异常, 请重新登录!";
            }
            else
            {
                if (!string.IsNullOrEmpty(update.Password.Trim()))
                {
                    customer.Password = update.Password;
                }
                if (!string.IsNullOrEmpty(update.Phone.Trim()))
                {
                    customer.Phone = update.Phone;
                }
                if (update.Birthday != DateTime.MinValue)
                {
                    customer.Birthday = update.Birthday;
                }
                bool ret = await Service.UpdateCustomer(customer);
                if (ret)
                {
                    res["status"] = "success";
                    res["message"] = "更新成功!";
                }
                else
                {
                    res["status"] = "failed";
                    res["message"] = "服务器错误!";
                }
            }
            return res;
        }

    }
}
