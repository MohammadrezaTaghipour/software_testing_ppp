namespace sessionFour.App.TestSpy;

public class FlightService
{
    private readonly INotificationService _notificationService;

    public FlightService(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public bool RegisterFlight(Flight flight)
    {
        _notificationService.SendSms($"Dear passenger : {flight.Passenger}, The Ticket is register with following info." +
                                     $"From: {flight.From} To: {flight.To}");
        
        return true;
    }
}