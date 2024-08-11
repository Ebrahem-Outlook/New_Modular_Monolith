using MediatR;

namespace Monolith.Domain.Core.Events;

/// <summary>
/// 
/// </summary>
public interface IDomainEvent : INotification
{
    Guid EventId { get; }
    DateTime OccuredOn { get; }
}
