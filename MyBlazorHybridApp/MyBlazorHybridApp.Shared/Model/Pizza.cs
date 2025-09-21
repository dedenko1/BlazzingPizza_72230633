using System.Collections.Generic;
using System.Linq;

namespace MyBlazorHybridApp.Shared.Model
{
    /// <summary>
    /// Represents a customized pizza as part of an order
    /// </summary>
    public class Pizza
    {
        public const int DefaultSize = 12;
        public const int MinimumSize = 9;
        public const int MaximumSize = 17;

        public int Id { get; set; }

        public int OrderId { get; set; }

        public PizzaSpecial Special { get; set; } = new PizzaSpecial();

        public int SpecialId { get; set; }

        public int Size { get; set; }

        public List<PizzaTopping> Toppings { get; set; } = new List<PizzaTopping>();

        public double GetBasePrice()
        {
            return ((double)Size / (double)DefaultSize) * Special.BasePrice;
        }

        public double GetTotalPrice()
        {
            return GetBasePrice();
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}
