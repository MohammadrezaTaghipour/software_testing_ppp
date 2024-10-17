namespace sessionFive.App.FakeObject;

public class FlightService(IRepository repository)
{
    public IRepository Repository { get; } = repository;

    public void CreateAirport(Airport airport)
    {
        Repository.CreateAirport(airport);
    }

    public void RegisterFlight(Flight flight)
    {
        repository.CreateFlight(flight);
    }

    public List<Flight> GetFlightsOfAirport(string airport)
    {
        return repository.GetFlightsOfAirport(airport);
    }

    public Airport GetAirport(string airportTitle)
    {
        return repository.GetAirport(airportTitle);
    }
}

public interface IRepository
{
    void CreateAirport(Airport airport);
    void CreateFlight(Flight flight);
    List<Flight> GetFlightsOfAirport(string airport);
    Airport GetAirport(string airportTitle);
}