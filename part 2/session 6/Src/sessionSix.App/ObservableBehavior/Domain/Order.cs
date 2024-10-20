namespace sessionSix.App.ObservableBehavior.Domain;

public class Order
{
    public string Id { get; set; }
    public Store Store { get; set; }
    public Discount? Discount { get; set; }
    public Customer Customer { get; set; }
    public List<Product> Products { get; set; }
}