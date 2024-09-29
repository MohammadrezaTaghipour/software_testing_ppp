namespace sessionOne.App;

public class Customer
{
    public bool Purchase(IStore store, string name, int quantity)
    {
        if (!store.HasEnoughInventory(name, quantity))
            return false;
        
        //TODO...

        store.RemoveInventory(name, quantity);
        return true;
    }
}