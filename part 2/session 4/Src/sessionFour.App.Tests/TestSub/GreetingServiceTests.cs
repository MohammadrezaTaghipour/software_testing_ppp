using FluentAssertions;
using NSubstitute;
using sessionFour.App.TestStub;
using Xunit;

namespace sessionFour.App.Tests.TestSub;

public class GreetingServiceTests
{
    //Erratic test
    [Theory]
    [InlineData(5, "Good Morning")]
    [InlineData(11, "Good Morning")]
    [InlineData(12, "Good Afternoon")]
    [InlineData(16, "Good Afternoon")]
    [InlineData(17, "Good Evening")]
    public void greeting_message_is_produced_properly_ErraticTest(int hour, string expected)
    {
        //Arrange
        var sut = new GreetingService();

        //Act
        var actual = sut.Greet();

        //Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, "Good Morning")]
    [InlineData(11, "Good Morning")]
    [InlineData(12, "Good Afternoon")]
    [InlineData(16, "Good Afternoon")]
    [InlineData(17, "Good Evening")]
    public void greeting_message_is_produced_properly(int hour, string expected)
    {
        //Arrange
        var sut = new GreetingService();
        var timeProvider = Substitute.For<ITimeProvider>();
        timeProvider.GetCurrentHour().Returns(hour);

        //Act
        var actual = sut.Greet_v2(timeProvider);

        //Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, "Good Morning")]
    [InlineData(11, "Good Morning")]
    [InlineData(12, "Good Afternoon")]
    [InlineData(16, "Good Afternoon")]
    [InlineData(17, "Good Evening")]
    public void greeting_message_is_produced_properly_HandCodedVersion(int hour, string expected)
    {
        //Arrange
        var sut = new GreetingService();
        var timeProvider = new TimeProviderTestSub();
        timeProvider.SetHour(hour);

        //Act
        var actual = sut.Greet_v2(timeProvider);

        //Assert
        actual.Should().Be(expected);
    }
}