using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorHybridApp.Shared.Data
{
    public class PizzaService
    {
        private static readonly Pizza[] Pizzas = new[]
        {
            new Pizza { PizzaId = 1, Name = "Margherita", Description = "Classic pizza with tomatoes, mozzarella, and basil", Price = 9.99m, Vegetarian = true, Vegan = false },
            new Pizza { PizzaId = 2, Name = "Pepperoni", Description = "All-time favorite with spicy pepperoni and cheese", Price = 11.50m, Vegetarian = false, Vegan = false },
            new Pizza { PizzaId = 3, Name = "Veggie Delight", Description = "Loaded with fresh vegetables", Price = 10.00m, Vegetarian = true, Vegan = true },
        };
        public Task<Pizza[]> GetPizzasAsync()
        {
            return Task.FromResult(Pizzas);
        }
    }
}
