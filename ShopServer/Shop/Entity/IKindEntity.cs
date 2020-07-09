using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models.ORM.Good;

namespace Shop.Entity
{
    public interface IKindEntity
    {
        public Task<Kind> GetKindByName(string name);

        public Task AddNewKind(Kind kind);

    }
}
