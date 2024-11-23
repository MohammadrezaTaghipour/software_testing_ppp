using sessionTen.App.Domain;

namespace sessionTen.App.Infrastructure.Framework;

public interface IEventDispatcher
{
    public void Dispatch(IReadOnlyList<IDomainEvent> events);
}

public class EventDispatcher(IMessageBus messageBus) : IEventDispatcher
{
    public void Dispatch(IReadOnlyList<IDomainEvent> events)
    {
        foreach (var ev in events)
        {
            Dispatch(ev);
        }
    }

    private void Dispatch(IDomainEvent ev)
    {
        switch (ev)
        {
            case UserEmailChanged emailChanged:
                messageBus.SendEmailChangedMessage(emailChanged.UserId, emailChanged.NewEmail);
                break;
            case UserTypeChanged typeChanged:
                messageBus.SendUserTypeChangedMessage(typeChanged.UserId, typeChanged.Email, typeChanged.NewType);
                break;
        }
    }
}