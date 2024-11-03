using sessionNine.App.Infrastructure;
using sessionNine.App.Infrastructure.Framework;

namespace sessionNine.App.Domain;

public class UserTypeChanged(int userId, string email, UserType oldType, UserType newType) : IDomainEvent
{
    public int UserId { get; } = userId;
    public string Email { get; } = email;
    public UserType OldType { get; } = oldType;
    public UserType NewType { get; } = newType;
}