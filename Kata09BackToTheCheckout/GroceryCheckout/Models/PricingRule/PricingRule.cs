using GroceryCheckout.Models.PricingStrategy.Interface;

namespace GroceryCheckout.Models.PricingRule;

public class PricingRule
{
    public string Sku { get; }
    private readonly IPricingStrategy _pricingStrategy;

    public PricingRule(string sku, IPricingStrategy pricingStrategy)
    {
        Sku = sku;
        _pricingStrategy = pricingStrategy;
    }

    public decimal Apply(int itemCount, decimal unitPice)
    {
        return _pricingStrategy.Apply(itemCount, unitPice);
    }

}