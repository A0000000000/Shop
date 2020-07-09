using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.User;

namespace Shop.Entity
{
    public interface ILocationEntity
    {
        public Task<Location> GetLocationByName(string name);

        public Task AddNewLocation(Location location);
    }
}
