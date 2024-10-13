namespace sessionFour.App.MockObject;

public class FlightService
{
    private readonly INotificationService _notificationService;
    private readonly IGreetingService _greetingService;

    public FlightService(INotificationService notificationService, IGreetingService greetingService)
    {
        _notificationService = notificationService;
        _greetingService = greetingService;
    }

    public bool RegisterFlight(Flight flight)
    {
        var message = $"{_greetingService.Greet()} Dear Passenger: '{flight.Passenger}'.";
        _notificationService.SendSms(message);
        return true;
    }
}

public interface INotificationService
{
    void SendSms(string message);
}

public interface IGreetingService
{
    string Greet();
}

public class Flight(string flightNum, string from, string to, string passenger)
{
    public string FlightNum { get; } = flightNum;
    public string From { get; } = from;
    public string To { get; } = to;
    public string Passenger { get; } = passenger;
}