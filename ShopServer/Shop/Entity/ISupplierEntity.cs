using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Good;

namespace Shop.Entity
{
    public interface ISupplierEntity
    {
        public Task<Supplier> GetSupplierByName(string name);

        public Task AddNewSupplier(Supplier supplier);

    }
}
