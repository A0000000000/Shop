using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.User;

namespace Shop.Entity
{
    public interface IAdministratorEntity
    {

        public Task<Administrator> GetAdministratorByUsername(string username);

        public Task AddNewAdministrator(Administrator administrator);

    }
}
