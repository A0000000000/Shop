using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Utils;

namespace Shop.Entity
{
    public interface IProductSupplierEntity
    {
        public Task AddNewProductSupplier(ProductSupplier ps);
        public Task DeleteProductSupplier(ProductSupplier ps);
    }
}
