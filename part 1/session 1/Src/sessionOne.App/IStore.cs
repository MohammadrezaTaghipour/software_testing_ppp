namespace sessionOne.App;

public interface IStore
{
    bool HasEnoughInventory(string name, int quantity);
    bool RemoveInventory(string name, int quantity);
}