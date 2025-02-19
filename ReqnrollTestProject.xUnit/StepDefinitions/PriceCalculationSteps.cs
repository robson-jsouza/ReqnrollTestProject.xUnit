using Reqnroll;
using FluentAssertions;

namespace ReqnrollTestProject.xUnit.StepDefinitions
{
    [Binding]
    public class PriceCalculationSteps
    {
        private readonly PriceCalculator _priceCalculator = new();
        private Dictionary<string, int> _basket = new();
        private decimal _calculatedPrice;

        [Given(@"the client started shopping")]
        public void GivenTheClientStartedShopping()
        {
            _basket = new Dictionary<string, int>();
        }

        [Given(@"the client added (.*) pcs of ""(.*)"" to the basket")]
        public void GivenTheClientAddedPcsOfToTheBasket(int quantity, string itemName)
        {
            if (_basket.ContainsKey(itemName))
                _basket[itemName] += quantity;
            else
                _basket[itemName] = quantity;
        }

        [When(@"the basket is prepared")]
        public void WhenTheBasketIsPrepared()
        {
            _calculatedPrice = _priceCalculator.CalculatePrice(_basket);
        }

        [Then(@"the basket price should be \$(.*)")]
        public void ThenTheBasketPriceShouldBe(decimal expectedPrice)
        {
            _calculatedPrice.Should().Be(expectedPrice);
        }
    }
}
