using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.User;

namespace Shop.Service
{
    public interface IAdministratorService
    {

        public Task<Administrator> Login(Administrator administrator);

        public Task<bool> Register(Administrator administrator);

    }
}
