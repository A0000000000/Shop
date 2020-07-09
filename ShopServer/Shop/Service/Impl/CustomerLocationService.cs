using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Entity;
using Shop.Entity.Impl;

namespace Shop.Service.Impl
{
    public class CustomerLocationService: ICustomerLocationService
    {
        private readonly ICustomerLocationEntity Entity;

        public CustomerLocationService(ICustomerLocationEntity entity)
        {
            Entity = entity;
        }

    }
}
