using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Utils;

namespace Shop.Entity
{
    public interface ICustomerLocationEntity
    {

        public Task AddNewCustomerLocation(CustomerLocation customerLocation);

        public Task DeleteCustomerLocation(CustomerLocation customerLocation);

    }
}
