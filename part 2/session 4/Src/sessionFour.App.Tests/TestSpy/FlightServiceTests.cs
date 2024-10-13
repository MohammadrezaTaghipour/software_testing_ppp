using FluentAssertions;
using NSubstitute;
using sessionFour.App.TestSpy;
using Xunit;

namespace sessionFour.App.Tests.TestSpy;

public class FlightServiceTests
{
    [Fact]
    public void flight_is_registered_successfully_HandCoded()
    {
        //Arrange
        var notificationService = new NotificationServiceTestSpy();
        var sut = new FlightService(notificationService);
        var flight = new Flight("Tehran", "Kish", "John Doe");
        var expected = $"Dear passenger : {flight.Passenger}, The Ticket is register with following info." +
                       $"From: {flight.From} To: {flight.To}";

        //Act
        var actual = sut.RegisterFlight(flight);

        //Assert
        actual.Should().BeTrue();
        notificationService.NumOfCalls.Should().Be(1);
        notificationService.Message.Should().Be(expected);
    }
    
    [Fact]
    public void flight_is_registered_successfully()
    {
        //Arrange
        var notificationService = Substitute.For<INotificationService>();
        var sut = new FlightService(notificationService);
        var flight = new Flight("Tehran", "Kish", "John Doe");
        var expected = $"Dear passenger : {flight.Passenger}, The Ticket is register with following info." +
                       $"From: {flight.From} To: {flight.To}";

        //Act
        var actual = sut.RegisterFlight(flight);

        //Assert
        actual.Should().BeTrue();
        notificationService.Received(1).SendSms(expected);
    }
}