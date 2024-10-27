namespace sessionSeven.App.UnitTestingStyles.OutputBased;

public class PricingService
{
    // Side-effect-free designed method 
    public decimal CalculateDiscount(params Product[] products)
    {
        decimal discount = products.Length * 0.01m;
        return Math.Min(discount, 0.2m);
    }
}