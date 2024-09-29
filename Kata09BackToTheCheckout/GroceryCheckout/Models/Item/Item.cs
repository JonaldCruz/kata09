namespace GroceryCheckout.Models.Item;

public class Item
{
    public string Sku { get; }
    public decimal Price { get; }
    public Item(string sku, decimal price)
    {
        Sku = sku;
        Price = price;
    }
}