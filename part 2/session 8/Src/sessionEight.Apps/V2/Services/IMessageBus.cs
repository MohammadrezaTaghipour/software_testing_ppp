namespace sessionEight.Apps.V2.Services;

public interface IMessageBus
{
    void SendEmailChangedMessage(int userId, string newEmail);
}