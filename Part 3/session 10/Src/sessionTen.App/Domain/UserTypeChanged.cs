using sessionTen.App.Infrastructure.Framework;

namespace sessionTen.App.Domain;

public class UserTypeChanged(int userId, string email, UserType oldType, UserType newType) : IDomainEvent
{
    public int UserId { get; } = userId;
    public string Email { get; } = email;
    public UserType OldType { get; } = oldType;
    public UserType NewType { get; } = newType;
}