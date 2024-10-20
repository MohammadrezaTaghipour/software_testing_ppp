using sessionSix.App.ObservableBehavior.Services;

namespace sessionSix.App.ObservableBehavior.Controllers;

public class OrdersController(IOrderService orderService)
{
    //[HttpPost]
    public string CreateOrder(CreateOrderRequest request)
    {
        var response = orderService.CreateOrder(request);
        return response.Id;
    }
    
    //[HttpPut]
    public string UpdateOrder(ModifyOrderRequest request)
    {
        var response = orderService.UpdateOrder(request);
        return response.Id;
    }
}