using FluentAssertions;
using sessionSix.App.ObservableBehavior.Domain;
using Xunit;

namespace sessionSix.App.Tests.ObservableBehavior.Domain;

// The following unit tests are not that much valuable
// Because the SUT is doing trivial operation and 
// The SUT does not have encapsulated any behaviors
public class StoreTests
{
    [Fact]
    public void Store_is_Created_successfully()
    {
        //Arrange
        var storeId = Guid.NewGuid().ToString();
        var storeName = Guid.NewGuid().ToString();
        
        //Act
        var sut = new Store
        {
            Id = storeId,
            Name = storeName,
            IsActive = true
        };

        //Assert
        sut.Id.Should().Be(storeId);
        sut.Name.Should().Be(storeName);
        sut.IsActive.Should().BeTrue();
    }
}