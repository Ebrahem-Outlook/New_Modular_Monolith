using Monolith.Domain.Core.Events;

namespace Monolith.Domain.Users.Events;

public sealed record UserCreatedDomainEvent(User User) : DomainEvent();
