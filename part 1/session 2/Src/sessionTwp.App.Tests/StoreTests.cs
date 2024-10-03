using FluentAssertions;
using sessionTwo.App;
using TestStack.BDDfy;
using Xunit;

namespace sessionTwp.App.Tests;

public class StoreTests
{
    private Store _sut;
    
    [Fact]
    public void Product_added_successfully()
    {
        // Arrange
        var sut = new Store();

        // Act
        sut.AddProduct("Shampoo", 1);

        // Assert
        var actual = sut.GetProduct("Shampoo");
        actual.Should().Be(1);
    }


    
    [Fact]
    public void Product_added_successfully_v2()
    {
        this.Given(s => s.There_is_a_store())
            .When(s=> s.New_product_is_added("Shampoo", 1))
            .Then(s=> s.Product_is_added_successfully("Shampoo", 1))
            .BDDfy();
    }
    
    void There_is_a_store()
    {
        _sut = new Store();
    }

    void New_product_is_added(string title, int quantity)
    {
        _sut.AddProduct(title, quantity);
    }

    void Product_is_added_successfully(string title, int quantity)
    {
        var actual = _sut.GetProduct(title);
        actual.Should().Be(quantity);
    }
}