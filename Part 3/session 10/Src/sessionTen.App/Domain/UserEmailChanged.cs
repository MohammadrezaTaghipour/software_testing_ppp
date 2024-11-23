using sessionTen.App.Infrastructure.Framework;

namespace sessionTen.App.Domain;

public class UserEmailChanged(int userId, string oldEmail, string newEmail) : IDomainEvent
{
    public int UserId { get; } = userId;
    public string OldEmail { get; } = oldEmail;
    public string NewEmail { get; } = newEmail;
}