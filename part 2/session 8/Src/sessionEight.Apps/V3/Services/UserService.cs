using sessionEight.Apps.V3.Domain;

namespace sessionEight.Apps.V3.Services;

public class UserService(IDatabase database, IMessageBus messageBus)
{
    public void ChangeEmail(int userId, string newEmail)
    {
        var user = database.GetUserById(userId);
        if (user.CanChangeEmail() == false) // warning: decision-point in services
        {
            throw new Exception("Email is not confirmed yet");
        }

        var company = database.GetCompany();

        user.ChangeEmail(newEmail, company);

        database.SaveCompany(company);
        database.SaveUser(user);

        foreach (var emailChangedEvent in user.DomainEvents.Cast<EmailChangedEvent>())
        {
            messageBus.SendEmailChangedMessage(emailChangedEvent.UserId, emailChangedEvent.NewEmail);
        }
    }
}