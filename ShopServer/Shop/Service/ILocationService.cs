using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.User;

namespace Shop.Service
{
    public interface ILocationService
    {

        public Task<bool> AddNewLocation(Customer customer, Location location);

        public Task<bool> DeleteLocation(Customer customer, Location location);

    }
}
