using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.DTO.User;
using Shop.Models.ORM.User;

namespace Shop.Service
{
    public interface ICustomerService
    {
        public Task<int> Register(Customer customer);

        public Task<Customer> Login(string username, string password);

        public Task<Customer> GetCustomerByUsername(string username);

        public Task<bool> UpdateCustomer(Customer customer);

        public Task<List<CustomerInfoDTO>> GetAllCustomers();

    }
}
