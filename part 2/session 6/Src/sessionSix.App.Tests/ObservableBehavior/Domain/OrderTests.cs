using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

// The following unit tests are not that much valuable
// Because the SUT is doing trivial operation and 
// The SUT does not have encapsulated any behaviors
public class OrderTests
{
    [Fact]
    public void Order_is_Created_successfully()
    {
        //Arrange
        var orderId = Guid.NewGuid().ToString();
        var store = new Store();
        var discount = new Discount();
        var customer = new Customer();
        var products = new List<Product>
        {
            new Product()
        };
        
        //Act
        var sut = new Order
        {
            Id = orderId,
            Store = store,
            Discount = discount,
            Customer = customer,
            Products = products
        };

        //Assert
        sut.Id.Should().Be(orderId);
        sut.Store.Should().Be(store);
        sut.Discount.Should().Be(discount);
        sut.Customer.Should().Be(customer);
        sut.Products.Should().BeEquivalentTo(products);
    }
}