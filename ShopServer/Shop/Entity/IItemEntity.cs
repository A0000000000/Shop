using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Shop;

namespace Shop.Entity
{
    public interface IItemEntity
    {
        public Task AddItem(Item item);
    }
}
