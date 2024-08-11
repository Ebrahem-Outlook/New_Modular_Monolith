using Monolith.Application.Core.Abstractions.Messaging;

namespace Monolith.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string Name, 
    string Bio, 
    string UserName, 
    string Email, 
    string Password) : ICommand<string>;
