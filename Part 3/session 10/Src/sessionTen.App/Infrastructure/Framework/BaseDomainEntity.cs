namespace sessionTen.App.Infrastructure.Framework;

public abstract class BaseDomainEntity
{
    protected readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
}