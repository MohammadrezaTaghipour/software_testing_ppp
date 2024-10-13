using System.Text.RegularExpressions;
using sessionFour.App.MockObject;

namespace sessionFour.App.Tests.MockObject;

public class NotificationServiceMock : INotificationService
{
    private string _pattern = $"(.*) Dear Passenger: '(.*)'.";
    private string _message;
    
    public void SendSms(string message)
    {
        var regex = new Regex(_pattern);
        if (!regex.IsMatch(message))
            throw new Exception($"Invalid SMS message. Message is {message} ");
        else
            _message = message;
    }
}