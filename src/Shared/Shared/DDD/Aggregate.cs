namespace Shared.DDD;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];
    private readonly IReadOnlyList<IDomainEvent> _readOnlyDomainEvents;

    protected Aggregate()
    {
        _readOnlyDomainEvents = _domainEvents.AsReadOnly();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    //Implemented from interface IAggregate
    public IReadOnlyList<IDomainEvent> DomainEvents => _readOnlyDomainEvents;

    public IDomainEvent[] ClearDomainEvents()
    {
        var domainEvents = _domainEvents.ToArray();
        _domainEvents.Clear();
        return domainEvents;
    }
}