namespace Monolith.Application.Core.Abstractions.Authentication;

public interface IUserIdentifierProvider
{
    Guid UserId { get; }
}
