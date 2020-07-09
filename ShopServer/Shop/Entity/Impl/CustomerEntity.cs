using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.User;

namespace Shop.Entity.Impl
{
    public class CustomerEntity: ICustomerEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Customer> Customers;
        
        public CustomerEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Customers = context.Customers;
        }

        public async Task AddNewCustomer(Customer customer)
        {
            await Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByUsername(string username)
        {
            Customer customer = await Customers.Where(c => c.Username == username).Include(c => c.CustomerLocations).ThenInclude(cl => cl.Location).FirstOrDefaultAsync();
            return customer;
        }

        public async Task UpdateCustomer(Customer customer)
        {
            Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await Customers.ToListAsync();
        }
    }
}
