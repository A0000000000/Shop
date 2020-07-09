using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.Shop;

namespace Shop.Entity.Impl
{
    public class ItemEntity: IItemEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Item> Items;

        public ItemEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Items = context.Items;
        }

        public async Task AddItem(Item item)
        {
            await Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
