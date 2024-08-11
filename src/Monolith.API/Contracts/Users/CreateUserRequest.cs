namespace Monolith.API.Contracts.Users;

public sealed record CreateUserRequest(
    string Name, 
    string Bio, 
    string UserName, 
    string Email, 
    string Password);
