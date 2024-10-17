namespace sessionFive.App.FakeObject;

public class Flight(string from, string to, Airport airport)
{
    public string From { get; } = from;
    public string To { get; } = to;
    public Airport Airport { get; } = airport;
}