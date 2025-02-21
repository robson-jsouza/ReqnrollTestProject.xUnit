namespace ReqnrollTestProject.xUnit
{
    public class PriceCalculator
    {
        // Predefined item prices
        private readonly Dictionary<string, decimal> _priceList = new()
        {
            { "Electric guitar", 180m },
            { "Guitar pick", 1.5m }
        };

        /// <summary>
        /// Calculates the total price of the items in the basket.
        /// </summary>
        /// <param name="basket">Dictionary where the key is the item name and the value is the quantity.</param>
        /// <returns>Total price of all items in the basket.</returns>
        public decimal CalculatePrice(Dictionary<string, int> basket)
        {
            decimal totalPrice = 0m;

            foreach (KeyValuePair<string, int> item in basket)
            {
                if (_priceList.TryGetValue(item.Key, out decimal unitPrice))
                {
                    totalPrice += unitPrice * item.Value; // Multiply price by quantity
                }
                else
                {
                    throw new ArgumentException($"Unknown item: {item.Key}");
                }
            }

            return totalPrice;
        }
    }
}
