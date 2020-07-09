using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.Utils;

namespace Shop.Entity.Impl
{
    public class CustomerLocationEntity: ICustomerLocationEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<CustomerLocation> CustomerLocations;

        public CustomerLocationEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            CustomerLocations = context.CustomerLocations;
        }

        public async Task AddNewCustomerLocation(CustomerLocation customerLocation)
        {
            await CustomerLocations.AddAsync(customerLocation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerLocation(CustomerLocation customerLocation)
        {
            CustomerLocations.Remove(customerLocation);
            await _context.SaveChangesAsync();
        }
    }
}
