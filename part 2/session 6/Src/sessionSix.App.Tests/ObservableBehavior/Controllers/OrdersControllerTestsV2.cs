using FluentAssertions;
using NSubstitute;
using sessionSix.App.ObservableBehavior.Controllers;
using sessionSix.App.ObservableBehavior.Domain;
using sessionSix.App.ObservableBehavior.Services;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Controllers;

// The following unit tests are not that much valuable
// All tests are Fragile and can't resist to refactoring
// Lots of implementation details are in the test body
public class OrdersControllerTestsV2
{
    private readonly IStoreRepository _storeRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    private readonly OrdersController _sut;

    public OrdersControllerTestsV2()
    {
        _storeRepository = Substitute.For<IStoreRepository>();
        _discountRepository = Substitute.For<IDiscountRepository>();
        _customerRepository = Substitute.For<ICustomerRepository>();
        _productRepository = Substitute.For<IProductRepository>();
        _orderRepository = Substitute.For<IOrderRepository>();

        var service = new OrderService(_storeRepository, _discountRepository,
            _customerRepository, _productRepository, _orderRepository);

        _sut = new OrdersController(service);
    }

    [Fact]
    public void Order_is_created_successfully()
    {
        //Arrange 
        var request = new CreateOrderRequest
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = Guid.NewGuid().ToString(),
            StoreId = Guid.NewGuid().ToString(),
            DiscountCode = Guid.NewGuid().ToString(),
            Products =
            [
                new ProductRequestItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = 10
                },

                new ProductRequestItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = 10
                }
            ]
        };
        _storeRepository.GetBy(request.StoreId).Returns(new Store
        {
            Id = request.Id,
            IsActive = true
        });
        _customerRepository.GetBy(request.CustomerId).Returns(new Customer
        {
            Id = request.Id,
            IsActive = true
        });
        foreach (var productRequestItem in request.Products)
        {
            _productRepository.GetBy(productRequestItem.Id).Returns(new Product
            {
                Id = productRequestItem.Id,
                Price = 100
            });
        }

        //Act
        var actual = _sut.CreateOrder(request);

        //Assert
        actual.Should().Be(request.Id);
    }

    [Fact]
    public void Order_is_modified_successfully()
    {
        //Arrange 
        var request = new ModifyOrderRequest
        {
            Id = Guid.NewGuid().ToString(),
            CustomerId = Guid.NewGuid().ToString(),
            StoreId = Guid.NewGuid().ToString(),
            DiscountCode = Guid.NewGuid().ToString(),
            Products =
            [
                new ProductRequestItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = 10
                },

                new ProductRequestItem
                {
                    Id = Guid.NewGuid().ToString(),
                    Quantity = 10
                }
            ]
        };
        _orderRepository.GetBy(request.Id).Returns(new Order
        {
            Id = request.Id,
        });
        _storeRepository.GetBy(request.StoreId).Returns(new Store
        {
            Id = request.Id,
            IsActive = true
        });
        _customerRepository.GetBy(request.CustomerId).Returns(new Customer
        {
            Id = request.Id,
            IsActive = true
        });
        foreach (var productRequestItem in request.Products)
        {
            _productRepository.GetBy(productRequestItem.Id).Returns(new Product
            {
                Id = productRequestItem.Id,
                Price = 100
            });
        }

        //Act
        var actual = _sut.UpdateOrder(request);

        //Assert
        actual.Should().Be(request.Id);
    }
}