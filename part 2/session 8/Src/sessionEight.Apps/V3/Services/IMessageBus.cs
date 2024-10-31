namespace sessionEight.Apps.V3.Services;

public interface IMessageBus
{
    void SendEmailChangedMessage(int userId, string newEmail);
}