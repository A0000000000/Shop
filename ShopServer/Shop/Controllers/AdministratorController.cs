using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Filter;
using Shop.Models.DTO.User;
using Shop.Models.ORM.User;
using Shop.Service;
using Shop.Tools;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AdministratorController: ControllerBase
    {

        private readonly IAdministratorService Service;
        private readonly ICustomerService CustomerService;

        public AdministratorController(IAdministratorService service, ICustomerService customerService)
        {
            Service = service;
            CustomerService = customerService;
        }

        [HttpPost]
        public async Task<Dictionary<string, object>> Login(Administrator administrator)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            Administrator tmp = await Service.Login(administrator);
            if (tmp == null)
            {
                res["status"] = "failed";
                res["message"] = "用户名或密码错误!";
            }
            else
            {
                res["status"] = "success";
                res["token"] = JWTTools.Encode(tmp.Username, DateTime.Now.AddDays(1), true);
            }
            return res;
        }

        [HttpPost]
        [LoginFilter(true)]
        public async Task<Dictionary<string, object>> AddNewAdministrator(Administrator administrator)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            bool ret = await Service.Register(administrator);
            if (ret)
            {
                res["status"] = "success";
                res["message"] = "添加成功!";
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
        public async Task<List<CustomerInfoDTO>> GetAllCustomers()
        {
            return await CustomerService.GetAllCustomers();
        }

    }
}
