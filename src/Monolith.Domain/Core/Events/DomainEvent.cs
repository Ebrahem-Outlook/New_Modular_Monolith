namespace Monolith.Domain.Core.Events;

public abstract record DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        EventId = Guid.NewGuid();
        OccuredOn = DateTime.UtcNow;
    }

    public Guid EventId { get; }

    public DateTime OccuredOn { get; }
}
