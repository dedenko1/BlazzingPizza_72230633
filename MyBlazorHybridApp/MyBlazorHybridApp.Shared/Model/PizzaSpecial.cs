namespace MyBlazorHybridApp.Shared.Model
{
    /// <summary>
    /// Represents a pre-configured template for a pizza a user can order
    /// </summary>
    public class PizzaSpecial
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double BasePrice { get; set; } = 0;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
    }
}
