using sessionSeven.App.UnitTestingStyles.OutputBased;
using Xunit;

namespace sessionSeven.App.Tests.UnitTestingStyles.OutputBased;

// The output-based style of unit testing is also known as functional.
// This is a a method of programming that emphasizes a preference for side-effect-free code.
public class PricingServiceTests
{
    [Fact]
    public void Discount_of_two_products()
    {
        //Arrange
        var product1 = new Product("Hand wash");
        var product2 = new Product("Shampoo");
        var sut = new PricingService();
        
        //Act
        decimal discount = sut.CalculateDiscount(product1, product2);
        
        //Assert
        Assert.Equal(0.02m, discount);
    }
}