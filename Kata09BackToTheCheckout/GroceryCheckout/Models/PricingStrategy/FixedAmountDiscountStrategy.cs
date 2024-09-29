using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingStrategy;

public class FixedAmountDiscountStrategy : IPricingStrategy
{
    public decimal Apply(int itemCount, decimal unitPrice)
    {
        throw new NotImplementedException();
    }
}