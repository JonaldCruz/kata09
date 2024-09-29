using GroceryCheckout.Models.Item;
using GroceryCheckout.Models.PricingRule;

namespace GroceryCheckout.Services;

public class CheckoutService
{
    private Dictionary<string, int> _scannedItems;
    private Dictionary<string, Item> _itemsInventory;
    private Dictionary<string, PricingRule> _pricingRules;
    private decimal _runningTotal = 0;

    public CheckoutService(Dictionary<string, PricingRule> pricingRules, Dictionary<string, Item> itemsInventory)
    {
        _pricingRules = pricingRules;
        _itemsInventory = itemsInventory;
    }

    public void setPricingRules(Dictionary<string, PricingRule> pricingRules)
    {
        _pricingRules = pricingRules;
    }

    public void startCheckout()
    {
        _scannedItems = new Dictionary<string, int>();
        _runningTotal = 0;
    }


    // quanity - for batch scanning
    public void Scan(string sku, int quantity = 1)
    {
        if (_scannedItems.TryGetValue(sku, out int count))
        {
            _scannedItems[sku] = count + quantity;
        }
        else
        {
            _scannedItems[sku] = quantity;
        }
        
        
    }
    
    public decimal ComputeTotal()
    {
        decimal total = 0;

        foreach (var sku in _scannedItems.Keys)
        {
            var item = _itemsInventory[sku];
            var itemQuantity = _scannedItems[sku];

            if (_pricingRules.ContainsKey(sku))
            {
                var rule = _pricingRules[sku];
                total += rule.Apply(itemQuantity, item.Price);
            }
            else
            {
                total += itemQuantity * item.Price;
            }
        }

        return total;
    }

}