namespace sessionSix.App.ObservableBehavior.Domain;

public interface IDiscountRepository
{
    Discount? GetBy(string? id);
}