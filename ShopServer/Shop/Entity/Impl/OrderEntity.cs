using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DatabaseContext;
using Shop.Models.ORM.Shop;

namespace Shop.Entity.Impl
{
    public class OrderEntity: IOrderEntity
    {
        private readonly SqlServerDatabaseContext _context;
        private readonly DbSet<Order> Orders;

        public OrderEntity(SqlServerDatabaseContext context)
        {
            _context = context;
            Orders = context.Orders;
        }

        public async Task AddOrder(Order order)
        {
            await Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }
    }
}
