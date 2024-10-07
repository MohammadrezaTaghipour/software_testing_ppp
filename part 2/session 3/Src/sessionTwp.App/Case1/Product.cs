namespace sessionTwp.App.Case1;

public class Product
{
    public Product(int id, string name, int quantity )
    {
        Id = id;
        Quantity = quantity;
        Name = name;
    }

    public int Id { get ; private set; }
    public string Name { get ; private set; }
    public int Quantity { get; private set; }

    public void DecreaseQuantity(int qunatity)
    {
        Quantity -= qunatity;
    }
}