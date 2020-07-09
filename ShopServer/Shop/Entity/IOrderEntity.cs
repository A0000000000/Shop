using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Shop;

namespace Shop.Entity
{
    public interface IOrderEntity
    {

        public Task AddOrder(Order order);

    }
}
