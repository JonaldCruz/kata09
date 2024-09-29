
using GroceryCheckout.Models.Item;
using GroceryCheckout.Models.PricingRule;
using GroceryCheckout.Models.PricingStrategy;
using GroceryCheckout.Services;

public class Program
{
    // not percentage
    // item count
    // dates avaiolable
    
    public static void Main(string[] args)
    {


        /*
         * ITEM, Price
         * COK-12OZ-12PK, 42
         * NPL-WATER-16OZ-24PK, 30
         */
        var item1 = new Item("COK-12OZ", 4);
        var item2 = new Item("NPL-WATER-16OZ", 30);
        var item3 = new Item("ARP-16OZ", 12);
        var item4 = new Item("FANTA-16OZ", 12);

        var itemsInventory = new Dictionary<string, Item>
        {
            { "COK-12OZ", item1 },
            { "NPL-WATER-16OZ", item2 },
            { "ARP-16OZ", item3 },
            { "FANTA-16OZ", item4}
        };
        
        /*
         * Item, DISCODE, price, start-end date
         * COK-12OZ-12PK, COK3FOR20, SpecialPrice, now, 1 week after
         */
        
        //other pricing rules: 10% off; get 1 item free
        var pricingRule1 = new PricingRule("COK3FOR20", new SpecialPriceStrategy(3, 10));
        var pricingRule2 = new PricingRule("NPLBUY1GET2", new BuyOneGetOneFreeStrategy());
        var pricingRule3 = new PricingRule("ARPBULKDISC", new BulkDiscountStrategy(3, 10));
        var pricingRule4 = new PricingRule("FANTAPERCENT", new PercentageDiscountStrategy(1, 0.50));

        var pricingRules = new Dictionary<string, PricingRule>()
        {
            {"COK-12OZ", pricingRule1}, 
            {"NPL-WATER-16OZ", pricingRule2},
            {"ARP-16OZ", pricingRule3},
            {"FANTA-16OZ", pricingRule4}
        };

        var checkout = new CheckoutService(pricingRules, itemsInventory);
        checkout.startCheckout();
        
        checkout.Scan("COK-12OZ");
        checkout.Scan("NPL-WATER-16OZ");
        checkout.Scan("NPL-WATER-16OZ");
        checkout.Scan("COK-12OZ");
        checkout.Scan("ARP-16OZ");
        checkout.Scan("ARP-16OZ");
        checkout.Scan("COK-12OZ");
        checkout.Scan("ARP-16OZ");
        checkout.Scan( "FANTA-16OZ");
       

        var total = checkout.ComputeTotal();
        Console.Write("Total Price: " + total);

    }
}