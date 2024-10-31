namespace sessionEight.Apps.V3.Domain;

public class EmailChangedEvent(int userId, string newEmail) : DomainEvent
{
    public int UserId { get; } = userId;
    public string NewEmail { get; } = newEmail;
}

public abstract class DomainEvent
{
    
}