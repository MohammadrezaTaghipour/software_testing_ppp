namespace sessionTwp.App.Case1;

public class Store
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyList<Product> Products => _products.AsReadOnly();
    private List<Product> _products;

    public Store(int id, string name, List<Product> products)
    {
        Id = id;
        Name = name;
        _products = products;
    }

    public bool HasEnoughInventory(Product product)
    {
        return _products.Any(p => p.Id == product.Id && p.Quantity >= product.Quantity);
    }

    public Product GetInventory(int id)
    {
        return _products.First(p => p.Id == id);
    }

    public void DecreaseInventory(Product product)
    {
        var p = _products.First(p => p.Id == product.Id);
        p.DecreaseQuantity(product.Quantity);
    }
}