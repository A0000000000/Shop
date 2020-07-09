using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Entity;
using Shop.Entity.Impl;
using Shop.Models.DTO.User;
using Shop.Models.ORM.User;

namespace Shop.Service.Impl
{
    public class CustomerService: ICustomerService
    {
        private readonly ICustomerEntity Entity;

        public CustomerService(ICustomerEntity entity)
        {
            Entity = entity;
        }

        public async Task<int> Register(Customer customer)
        {
            try
            {
                if ((await Entity.GetCustomerByUsername(customer.Username)) != null)
                {
                    return 1;
                }
                customer.CreateTime = DateTime.Now;
                await Entity.AddNewCustomer(customer);
                return 0;
            }
            catch (Exception e)
            {
                return 2;
            }
        }

        public async Task<Customer> Login(string username, string password)
        {
            Customer customer = await Entity.GetCustomerByUsername(username);
            if (customer != null)
            {
                return customer.Password == password ? customer : null;
            }
            return null;
        }

        public async Task<Customer> GetCustomerByUsername(string username)
        {
            return await Entity.GetCustomerByUsername(username);
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            try
            {
                await Entity.UpdateCustomer(customer);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<List<CustomerInfoDTO>> GetAllCustomers()
        {
            List<Customer> customers = await Entity.GetAllCustomers();
            return customers.ConvertAll(c => new CustomerInfoDTO()
            {
                Id = c.Id,
                Birthday = c.Birthday,
                CreateTime = c.CreateTime,
                Email = c.Email,
                Phone = c.Phone,
                Username = c.Username
            });
        }
    }
}
