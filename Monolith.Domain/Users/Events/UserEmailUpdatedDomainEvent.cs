using Monolith.Domain.Core.Events;

namespace Monolith.Domain.Users.Events;

public sealed record UserEmailUpdatedDomainEvent(User User) : DomainEvent();
