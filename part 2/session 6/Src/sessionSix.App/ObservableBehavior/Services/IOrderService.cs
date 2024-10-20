using sessionSix.App.ObservableBehavior.Domain;

namespace sessionSix.App.ObservableBehavior.Services;

public interface IOrderService
{
    Order CreateOrder(CreateOrderRequest request);
    Order UpdateOrder(ModifyOrderRequest request);
}

public class OrderService(
    IStoreRepository storeRepository,
    IDiscountRepository discountRepository,
    ICustomerRepository customerRepository,
    IProductRepository productRepository,
    IOrderRepository orderRepository) : IOrderService
{
    public Order CreateOrder(CreateOrderRequest request)
    {
        var customer = customerRepository.GetBy(request.CustomerId);
        if (customer.IsActive == false)
            throw new Exception("Customer is deActivated");

        var store = storeRepository.GetBy(request.StoreId);
        if (store.IsActive == false)
            throw new Exception("Store is deActivated");

        var discount = discountRepository.GetBy(request.DiscountCode);
        if (discount is not null && discount.IsActive == false)
            throw new Exception("Invalid discount code");

        if (request.Products == null || request.Products.Any() == false)
            throw new Exception("AtLeast one product is required.");

        var products = request.Products.Select(p => productRepository.GetBy(p.Id)).ToList();

        if (products.Any(p => p.Price <= 0))
            throw new Exception("AtLeast one product is required.");

        var order = new Order
        {
            Id = request.Id,
            Store = store,
            Discount = discount,
            Customer = customer,
            Products = products
        };

        orderRepository.Add(order);

        return order;
    }

    public Order UpdateOrder(ModifyOrderRequest request)
    {
        var order = orderRepository.GetBy(request.Id);

        var customer = customerRepository.GetBy(request.CustomerId);
        if (customer.IsActive == false)
            throw new Exception("Customer is deActivated");

        var store = storeRepository.GetBy(request.StoreId);
        if (store.IsActive == false)
            throw new Exception("Store is deActivated");

        var discount = discountRepository.GetBy(request.DiscountCode);
        if (discount is not null && discount.IsActive == false)
            throw new Exception("Invalid discount code");

        if (request.Products == null || request.Products.Any() == false)
            throw new Exception("AtLeast one product is required.");

        var products = request.Products.Select(p => productRepository.GetBy(p.Id)).ToList();

        if (products.Any(p => p.Price <= 0))
            throw new Exception("AtLeast one product is required.");

        order.Store = store;
        order.Customer = customer;
        order.Discount = discount;
        order.Products = products;


        orderRepository.Add(order);

        return order;
    }
}