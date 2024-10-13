namespace sessionFour.App.TestStub;

public class GreetingService
{
    public string Greet()
    {
        var hour = DateTime.Now.Hour;

        return hour switch
        {
            >= 5 and < 12 => "Good Morning",
            >=12 and < 17 => "Good Afternoon",
            >=17 and < 23 => "Good Evening",
        };
    }
    
    public string Greet_v2(ITimeProvider timeProvider)
    {
        var hour = timeProvider.GetCurrentHour();

        return hour switch
        {
            >= 5 and < 12 => "Good Morning",
            >=12 and < 17 => "Good Afternoon",
            >=17 and < 23 => "Good Evening",
        };
    }
}