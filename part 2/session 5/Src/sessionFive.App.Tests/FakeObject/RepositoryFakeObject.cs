using sessionFive.App.FakeObject;

namespace sessionFive.App.Tests.FakeObject;

public class RepositoryFakeObject : IRepository
{
    private readonly Dictionary<string, Airport> _airports = new();
    private readonly Dictionary<string, List<Flight>> _flights = new();
    
    public void CreateAirport(Airport airport)
    {
        _airports.Add(airport.Title, airport);
    }

    public void CreateFlight(Flight flight)
    {
        if (_flights.TryGetValue(flight.Airport.Title, out var flights))
        {
            flights.Add(flight);
        }
        else
        {
            flights = new List<Flight>() { flight };
            _flights.Add(flight.Airport.Title, flights);
        }
    }

    public List<Flight> GetFlightsOfAirport(string airport)
    {
        return _flights[airport];
    }

    public Airport GetAirport(string airportTitle)
    {
        return _airports[airportTitle];
    }
}