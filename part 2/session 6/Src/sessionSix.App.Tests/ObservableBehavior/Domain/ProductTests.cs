using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

// The following unit tests are not that much valuable
// Because the SUT is doing trivial operation and 
// The SUT does not have encapsulated any behaviors
public class ProductTests
{
    [Fact]
    public void Product_is_Created_successfully()
    {
        //Arrange
        var productId = Guid.NewGuid().ToString();
        var productName = Guid.NewGuid().ToString();
        var productPrice = 3000;
        
        //Act
        var sut = new Product
        {
            Id = productId,
            Name = productName,
            Price = productPrice
        };

        //Assert
        sut.Id.Should().Be(productId);
        sut.Name.Should().Be(productName);
        sut.Price.Should().Be(productPrice);
    }
}