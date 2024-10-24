using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

// The following unit tests are not that much valuable
// Because the SUT is doing trivial operation and 
// The SUT does not have encapsulated any behaviors
public class CustomerTests
{
    [Fact]
    public void Customer_is_Created_successfully()
    {
        //Arrange
        var customerId = Guid.NewGuid().ToString();
        var customerName = Guid.NewGuid().ToString();
        
        //Act
        var sut = new Customer
        {
            Id = customerId,
            Name = customerName,
            IsActive = true
        };

        //Assert
        sut.Id.Should().Be(customerId);
        sut.Name.Should().Be(customerName);
        sut.IsActive.Should().BeTrue();
    }
}