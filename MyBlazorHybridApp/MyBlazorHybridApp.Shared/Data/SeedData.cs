using MyBlazorHybridApp.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlazorHybridApp.Shared.Data
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext db)
        {
            if (db.Specials.Any())
                return;

            var specials = new PizzaSpecial[]
            {
            new PizzaSpecial()
            {
                Name = "Basic Cheese Pizza",
                Description = "It's cheesy and delicious. Why wouldn't you want one?",
                BasePrice = 9.99,
                ImageUrl = "_content/MyBlazorHybridApp.Shared/img/pizzas/cheese.jpg",
            },
            new PizzaSpecial()
            {
                Id = 2,
                Name = "The Baconatorizor",
                Description = "It has EVERY kind of bacon",
                BasePrice = 11.99,
                ImageUrl = "_content/MyBlazorHybridApp.Shared/img/pizzas/bacon.jpg",
            },
            new PizzaSpecial()
            {
                Id = 3,
                Name = "Classic pepperoni",
                Description = "It's the pizza you grew up with, but Blazing hot!",
                BasePrice = 10.50,
                ImageUrl = "_content/MyBlazorHybridApp.Shared/img/pizzas/pepperoni.jpg",
            },
            new PizzaSpecial()
            {
                Id = 4,
                Name = "Buffalo chicken",
                Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                BasePrice = 12.75,
                ImageUrl = "_content/MyBlazorHybridApp.Shared/img/pizzas/meaty.jpg",
            },
            new PizzaSpecial()
            {
                Id = 5,
                Name = "Mushroom Lovers",
                Description = "It has mushrooms. Isn't that obvious?",
                BasePrice = 11.00,
                ImageUrl = "_content/MyBlazorHybridApp.Shared/img/pizzas/mushroom.jpg",
            },
            new PizzaSpecial()
            {
                Id = 7,
                Name = "Veggie Delight",
                Description = "It's like salad, but on a pizza",
                BasePrice = 11.50,
                ImageUrl = "_content/MyBlazorHybridApp.Shared/img/pizzas/salad.jpg",
            },
            new PizzaSpecial()
            {
                Id = 8,
                Name = "Margherita",
                Description = "Traditional Italian pizza with tomatoes and basil",
                BasePrice = 9.99,
                ImageUrl = "_content/MyBlazorHybridApp.Shared/img/pizzas/margherita.jpg",
            },
            };
            db.Specials.AddRange(specials);
            db.SaveChanges();
        }
    }
}
