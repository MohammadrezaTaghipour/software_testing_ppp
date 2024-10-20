namespace sessionSix.App.ObservableBehavior.Domain;

public interface ICustomerRepository
{
    Customer GetBy(string id);
}