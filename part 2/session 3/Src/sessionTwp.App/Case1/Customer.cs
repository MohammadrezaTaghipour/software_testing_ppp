namespace sessionTwp.App.Case1;

public class Customer
{
    public Customer(int id, string fullname)
    {
        Id = id;
        Fullname = fullname;
    }

    public int Id { get; private set; }
    public string Fullname { get; private set; }

    public bool Purchase(Product product, Store store)
    {
        if (!store.HasEnoughInventory(product))
            return false;

        store.DecreaseInventory(product);
        
        return true;
    }
}