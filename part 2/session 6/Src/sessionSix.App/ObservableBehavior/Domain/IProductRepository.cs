namespace sessionSix.App.ObservableBehavior.Domain;

public interface IProductRepository
{
    Product GetBy(string id);
}