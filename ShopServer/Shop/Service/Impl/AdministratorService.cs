using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Shop.Entity;
using Shop.Models.ORM.User;

namespace Shop.Service.Impl
{
    public class AdministratorService: IAdministratorService
    {
        private readonly IAdministratorEntity Entity;
        private readonly IConfiguration Configuration;

        public AdministratorService(IAdministratorEntity entity, IConfiguration configuration)
        {
            Entity = entity;
            Configuration = configuration;
        }


        public async Task<Administrator> Login(Administrator administrator)
        {
            try
            {
                IConfigurationSection section = Configuration.GetSection("DefaultAdministrator");
                string username = section.GetSection("username").Value;
                string password = section.GetSection("password").Value;
                if (administrator.Username == username && administrator.Password == password)
                {
                    return administrator;
                }
                if (administrator.Username == username)
                {
                    return null;
                }
                Administrator tmp = await Entity.GetAdministratorByUsername(administrator.Username);
                if (administrator.Password == tmp?.Password)
                {
                    return tmp;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Register(Administrator administrator)
        {
            try
            {
                await Entity.AddNewAdministrator(administrator);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
