using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingStrategy;

public class PercentageDiscountStrategy : IPricingStrategy
{
    private readonly int _minQuantity;
    private readonly double _discountPercentage;
    public PercentageDiscountStrategy(int minQuantity, double discountPercentage)
    {
        _minQuantity = minQuantity;
        _discountPercentage = discountPercentage;
    }

    public decimal Apply(int itemCount, decimal unitPrice)
    {
        // to implement buy 2 get 10 % off
        return itemCount * unitPrice * (decimal)_discountPercentage;
    }
}