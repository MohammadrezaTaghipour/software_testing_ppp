using FluentAssertions;
using NSubstitute;
using sessionSix.App.ObservableBehavior.Controllers;
using sessionSix.App.ObservableBehavior.Domain;
using sessionSix.App.ObservableBehavior.Services;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Controllers;

// The following unit tests are not that much valuable
// Because the SUT is doing trivial operation
public class OrdersControllerTests
{
    private readonly OrdersController _sut;
    private readonly IOrderService _service;

    public OrdersControllerTests()
    {
        _service = Substitute.For<IOrderService>();
        _sut = new OrdersController(_service);
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
        _service.CreateOrder(request).Returns(new Order
        {
            Id = request.Id,
        });

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
        _service.UpdateOrder(request).Returns(new Order
        {
            Id = request.Id,
        });

        //Act
        var actual = _sut.UpdateOrder(request);

        //Assert
        actual.Should().Be(request.Id);
    }
}