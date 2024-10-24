using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

// The following unit tests are not that much valuable
// Because the SUT is doing trivial operation and 
// The SUT does not have encapsulated any behaviors
public class DiscountTests
{
    [Fact]
    public void Discount_is_Created_successfully()
    {
        //Arrange
        var discountId = Guid.NewGuid().ToString();
        var discountCode = Guid.NewGuid().ToString();
        var discountAmount = 3000;

        //Act
        var sut = new Discount
        {
            Id = discountId,
            Code = discountCode,
            Amount = discountAmount,
            IsActive = true
        };

        //Assert
        sut.Id.Should().Be(discountId);
        sut.Code.Should().Be(discountCode);
        sut.Amount.Should().Be(discountAmount);
        sut.IsActive.Should().BeTrue();
    }
}