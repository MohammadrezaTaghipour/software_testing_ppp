namespace sessionSix.App.ObservableBehavior.Services;

public class CreateOrderRequest
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    public string StoreId { get; set; }
    public string? DiscountCode { get; set; }
    public List<ProductRequestItem> Products { get; set; }
}

public class ProductRequestItem
{
    public string Id { get; set; }
    public int Quantity { get; set; }
}

public class ModifyOrderRequest : CreateOrderRequest
{
    
}