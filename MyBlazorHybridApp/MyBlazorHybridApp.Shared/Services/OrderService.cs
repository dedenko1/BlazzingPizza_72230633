using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Shared.Data;
using MyBlazorHybridApp.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorHybridApp.Shared.Services
{
    public class OrderService
    {
        private readonly PizzaStoreContext _db;

        public OrderService(PizzaStoreContext db)
        {
            _db = db;
        }

        // Ambil semua order
        public async Task<List<OrderWithStatus>> GetOrdersAsync()
        {
            var orders = await _db.Orders
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                .OrderByDescending(o => o.CreatedTime)
                .ToListAsync();

            return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
        }

        public async Task<OrderWithStatus?> GetOrderWithStatusAsync(int orderId)
        {
            var order = await _db.Orders
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
                return null;

            return OrderWithStatus.FromOrder(order);
        }

        // Tambahkan order baru
        public async Task<int> PlaceOrderAsync(Order order)
        {
            order.CreatedTime = DateTime.Now;

            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;
            }

            _db.Orders.Attach(order);
            await _db.SaveChangesAsync();

            return order.OrderId;   
        }
    }
}
