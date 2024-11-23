using sessionTen.App.Domain;

namespace sessionTen.App.Infrastructure.Framework;

public interface IMessageBus
{
    void SendEmailChangedMessage(int userId, string newEmail);
    void SendUserTypeChangedMessage(int userId, string email, UserType newType);
}

public class MessageBus(IBus bus) : IMessageBus
{
    public void SendEmailChangedMessage(int userId, string newEmail)
    {
        bus.Send($"Type: USER EMAIL CHANGED; Id: {userId}; NewEmail: {newEmail}");
    }

    public void SendUserTypeChangedMessage(int userId, string email, UserType newType)
    {
        bus.Send($"Type: USER TYPE CHANGED; Id: {userId}; Email: {email}; NewType: {newType}");
    }
}