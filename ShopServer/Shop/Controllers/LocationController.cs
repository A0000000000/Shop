using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Filter;
using Shop.Models.ORM.User;
using Shop.Models.ORM.Utils;
using Shop.Service;

namespace Shop.Controllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class LocationController: ControllerBase
    {
        private readonly ILocationService Service;
        private readonly ICustomerService CustomerService;

        public LocationController(ILocationService service, ICustomerService customerService)
        {
            Service = service;
            CustomerService = customerService;
        }


        [HttpPost]
        [LoginFilter]
        public async Task<IEnumerable<Dictionary<string, object>>> GetLocations()
        {
            List<Dictionary<string, object>> res = new List<Dictionary<string, object>>();
            string username = Request.Headers["username"];
            Customer customer = await CustomerService.GetCustomerByUsername(username);
            IEnumerable<CustomerLocation> locations = customer?.CustomerLocations;
            if (locations != null)
            {
                foreach (CustomerLocation location in locations)
                {
                    res.Add(new Dictionary<string, object>
                    {
                        ["id"] = location?.Location?.Id,
                        ["zipCode"] = location?.Location?.ZipCode,
                        ["name"] = location?.Location?.Name
                    });
                }
            }
            return res;
        }

        [HttpPost]
        [LoginFilter]
        public async Task<Dictionary<string, object>> AddNewLocation(Location location)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            string username = Request.Headers["username"];
            Customer customer = await CustomerService.GetCustomerByUsername(username);
            bool ret = await Service.AddNewLocation(customer, location);
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
        [LoginFilter]
        public async Task<Dictionary<string, object>> RemoveLocation(Location location)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            string username = Request.Headers["username"];
            Customer customer = await CustomerService.GetCustomerByUsername(username);
            bool ret = await Service.DeleteLocation(customer, location);
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
