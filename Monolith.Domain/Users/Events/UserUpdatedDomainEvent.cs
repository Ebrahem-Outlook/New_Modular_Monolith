using Monolith.Domain.Core.Events;

namespace Monolith.Domain.Users.Events;

public sealed record UserUpdatedDomainEvent(User User) : DomainEvent();
