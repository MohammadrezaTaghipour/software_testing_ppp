namespace sessionSeven.App.UnitTestingStyles.StateBased;

public class Order
{
    private readonly List<Product> _products = new List<Product>();
    public IReadOnlyList<Product> Products => _products.AsReadOnly();
    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}