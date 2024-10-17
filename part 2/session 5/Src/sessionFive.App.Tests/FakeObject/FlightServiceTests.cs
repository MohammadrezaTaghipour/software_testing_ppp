using FluentAssertions;
using sessionFive.App.FakeObject;
using Xunit;

namespace sessionFive.App.Tests.FakeObject;

public class FlightServiceTests
{
    private readonly FlightService _sut;
    private Airport _airport;

    public FlightServiceTests()
    {
        IRepository repository = new RepositoryFakeObject();
        _sut = new FlightService(repository);
    }
    
    [Theory]
    [InlineData("Mehrabad")]
    public void Airport_gets_create_successfully(string airportTitle)
    {
        //Arrange
        _airport = new Airport(airportTitle);
        
        //Act
        _sut.CreateAirport(_airport);
        
        //Assert
        var actual = _sut.GetAirport(airportTitle);
        actual.Should().BeEquivalentTo(_airport);
    }
    
    [Fact]
    public void Flight_gets_registered_successfully()
    {
        //Arrange
        Airport_gets_create_successfully("Mehrabad");
        var flight = new Flight("Tehran", "Kish", _airport);
        
        //Act
        _sut.RegisterFlight(flight);

        //Assert
        var actual = _sut.GetFlightsOfAirport("Mehrabad");
        actual.Should().ContainEquivalentOf(flight);
    }
}