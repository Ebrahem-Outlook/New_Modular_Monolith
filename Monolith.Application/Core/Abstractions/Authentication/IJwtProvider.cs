using Monolith.Domain.Users;

namespace Monolith.Application.Core.Abstractions.Authentication;

public interface IJwtProvider
{
    string GenerateToken(User user);
}
