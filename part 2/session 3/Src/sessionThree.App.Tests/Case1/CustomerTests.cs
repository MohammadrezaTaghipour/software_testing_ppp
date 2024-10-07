using FluentAssertions;
using sessionTwp.App.Case1;
using Xunit;

namespace sessionThree.App.Tests.Case1;

public class CustomerTests
{
    private Customer sut;
    private Product product;
    private Store store;

    public CustomerTests()
    {
        sut = new Customer(1, "John Doe");
        var inventoryProduct = new Product(1, "Shampoo", 11);
        store = new Store(1, "IranMall", [inventoryProduct]);
    }
    
    [Theory]
    [InlineData(1, "Shampoo", 20)]
    public void Purchase_Succeeds_when_enough_inventory(int purchaseProductId, string purchaseProductName, int purchaseProductQuantity)
    {
        //Arrange
        var purchaseProduct = new Product(purchaseProductId, purchaseProductName, purchaseProductQuantity);

        //Act
        var actual = sut.Purchase(purchaseProduct, store);
        
        //Assert
        actual.Should().BeTrue();
    }

    [Theory]
    [InlineData(1, "Shampoo", 20)]
    public void Purchase_fails_when_not_enough_inventory(int purchaseProductId, string purchaseProductName, int purchaseProductQuantity)
    {
        //Arrange
        var purchaseProduct = new Product(purchaseProductId, purchaseProductName, purchaseProductQuantity);

        //Act
        var actual = sut.Purchase(purchaseProduct, store);
        
        //Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void Successful_purchase_modifies_inventory()
    {
        //Arrange
        Purchase_Succeeds_when_enough_inventory(1, "Shampoo", 10);
        
        //Act
        Purchase_fails_when_not_enough_inventory(1, "Shampoo", 11);

        //Assert
        Purchase_Succeeds_when_enough_inventory(1, "Shampoo", 10);
    }
}