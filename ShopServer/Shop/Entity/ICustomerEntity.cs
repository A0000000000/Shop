using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.User;

namespace Shop.Entity
{
    public interface ICustomerEntity
    {
        public Task AddNewCustomer(Customer customer);

        public Task<Customer> GetCustomerByUsername(string username);

        public Task UpdateCustomer(Customer customer);

        public Task<List<Customer>> GetAllCustomers();
    }
}
