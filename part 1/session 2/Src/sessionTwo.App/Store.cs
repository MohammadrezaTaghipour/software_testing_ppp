namespace sessionTwo.App;

public class Store
{
    private readonly Dictionary<string, int> _products = new();
    
    public void AddProduct(string title, int quantity)
    {
        _products.Add(title, quantity);
    }

    public int GetProduct(string title)
    {
        return _products[title];
    }
}