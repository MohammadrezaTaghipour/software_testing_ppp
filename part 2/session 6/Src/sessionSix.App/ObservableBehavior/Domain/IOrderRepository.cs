namespace sessionSix.App.ObservableBehavior.Domain;

public interface IOrderRepository
{
    Order GetBy(string id);
    void Add(Order order);
}