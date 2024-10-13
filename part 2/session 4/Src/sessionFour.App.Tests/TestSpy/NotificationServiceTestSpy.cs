using sessionFour.App.TestSpy;

namespace sessionFour.App.Tests.TestSpy;

public class NotificationServiceTestSpy : INotificationService
{
    public int NumOfCalls{ get; private set; }
    public string Message { get; private set; }
    
    public void SendSms(string message)
    {
        NumOfCalls += 1;
        Message = message;
    }
}