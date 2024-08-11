namespace Monolith.API.Contracts.Users;

public sealed record UpdateUserRequest(
    Guid UserId, 
    string Name, 
    string Bio);
