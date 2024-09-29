using FluentAssertions;
using NSubstitute;
using sessionOne.App;
using Xunit;

namespace sessionOne.Tests;

public class CustomerTests
{
    [Fact]
    public void Purchase_succeeds_when_enough_inventory()
    {
        //Arrange
        var store = NSubstitute.Substitute.For<IStore>();
        store.HasEnoughInventory(Arg.Any<string>(), Arg.Any<int>()).Returns(true);
        var customer = new Customer();

        //Act
        var result = customer.Purchase(store, "Shampoo", 5);

        //Assert
        result.Should().BeTrue();
        store.Received(1).RemoveInventory("Shampoo", 5);
    }
}