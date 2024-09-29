namespace GroceryCheckout.Models.PricingStrategy.Interface;

public interface IPricingStrategy
{
  //  protected DateTime StartDate { get; }
  //  protected DateTime EndDate { get; }
    decimal Apply(int itemCount, decimal unitPrice);
    
}