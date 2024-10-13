using FluentAssertions;
using NSubstitute;
using sessionFour.App.MockObject;
using Xunit;

namespace sessionFour.App.Tests.MockObject;

public class FlightServiceTests
{
    [Fact]
    public void flight_is_registered_successfully_HandCoded()
    {
        //Arrange
        var notificationService = new NotificationServiceMock();
        var greetingService = Substitute.For<IGreetingService>();
        greetingService.Greet().Returns("Good Morning");
        var sut = new FlightService(notificationService, greetingService);
        var flight = new Flight("IR-022", "Tehran", "Kish", "John Doe");
        
        //Act
        var actual = sut.RegisterFlight(flight);

        //Assert
        actual.Should().BeTrue();
    }
}