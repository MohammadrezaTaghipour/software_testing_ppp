using sessionFour.App.TestStub;

namespace sessionFour.App.Tests.TestSub;

public class TimeProviderTestSub : ITimeProvider
{
    private int _hour;

    public void SetHour(int hour)
    {
        _hour = hour;
    }
    
    public int GetCurrentHour()
    {
        return _hour;
    }
}