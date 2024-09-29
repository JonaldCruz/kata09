using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingStrategy;

public class BuyOneGetOneFreeStrategy : IPricingStrategy
{
    public decimal Apply(int itemCount, decimal unitPrice)
    {
        int paidItems = (itemCount + 1) / 2;  // Every second item is free
        return paidItems * unitPrice;
    }
}