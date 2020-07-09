using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Entity;
using Shop.Models.ORM.User;
using Shop.Models.ORM.Utils;

namespace Shop.Service.Impl
{
    public class LocationService: ILocationService
    {

        private readonly ILocationEntity Entity;
        private readonly ICustomerLocationEntity CustomerLocationEntity;
        public LocationService(ILocationEntity entity, ICustomerLocationEntity customerLocationEntity)
        {
            Entity = entity;
            CustomerLocationEntity = customerLocationEntity;
        }


        public async Task<bool> AddNewLocation(Customer customer, Location location)
        {

            try
            {
                Location tmp = await Entity.GetLocationByName(location.Name);
                if (tmp != null)
                {
                    CustomerLocation cl = new CustomerLocation()
                    {
                        Customer = customer,
                        Location = tmp
                    };
                    await CustomerLocationEntity.AddNewCustomerLocation(cl);
                }
                else
                {
                    await Entity.AddNewLocation(location);
                    CustomerLocation cl = new CustomerLocation()
                    {
                        Customer = customer,
                        Location = location
                    };
                    await CustomerLocationEntity.AddNewCustomerLocation(cl);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteLocation(Customer customer, Location location)
        {
            try
            {
                IEnumerable<CustomerLocation> enumerable = customer.CustomerLocations;
                CustomerLocation del = null;
                if (enumerable != null)
                {
                    foreach (CustomerLocation cl in enumerable)
                    {
                        if (location.Id == cl.Location.Id)
                        {
                            del = cl;
                            break;
                        }
                    }
                }
                if (del != null)
                {
                    await CustomerLocationEntity.DeleteCustomerLocation(del);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
