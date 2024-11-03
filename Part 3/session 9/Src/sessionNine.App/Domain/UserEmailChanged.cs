using sessionNine.App.Infrastructure;
using sessionNine.App.Infrastructure.Framework;

namespace sessionNine.App.Domain;

public class UserEmailChanged(int userId, string oldEmail, string newEmail) : IDomainEvent
{
    public int UserId { get; } = userId;
    public string OldEmail { get; } = oldEmail;
    public string NewEmail { get; } = newEmail;
}