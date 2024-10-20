namespace sessionSix.App.ObservableBehavior.Domain;

public interface IStoreRepository
{
    Store GetBy(string id);
}