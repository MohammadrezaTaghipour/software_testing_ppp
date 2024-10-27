using sessionSeven.App.UnitTestingStyles.StateBased;
using Xunit;

namespace sessionSeven.App.Tests.UnitTestingStyles.StateBased;

// The state-based style is about verifying the state of the system after an operation is complete.
// The term state in this style of testing can refer to the state of the...
// ...SUT itself, of one of its collaborators, or of an out-of-process dependency.
public class OrderTests
{
    [Fact]
    public void Adding_a_product_to_an_order()
    {
        //Arrange
        var product = new Product("Hand wash");
        var sut = new Order();
        
        //Act
        sut.AddProduct(product);
        
        //Assert
        Assert.Equal(1, sut.Products.Count);
        Assert.Equal(product, sut.Products[0]);
    }
}