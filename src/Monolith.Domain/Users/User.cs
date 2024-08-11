using Monolith.Domain.Core.BaseType;
using Monolith.Domain.Users.Events;

namespace Monolith.Domain.Users;

public sealed class User : AggregateRoot
{
    private User(string name, string bio, string userName, string email, string passwordHash)
        : base(Guid.NewGuid())
    {
        Name = name;
        Bio = bio ?? "";
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
    }

    private User() : base() { }

    public string Name { get; private set; } = default!;
    public string Bio { get; private set; } = default!;
    public string UserName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;

    public static User Create(string name, string bio, string userName, string email, string passwordHash)
    {
        User user = new(name, bio, userName, email, passwordHash);

        user.RaiseDomainEvent(new UserCreatedDomainEvent(user));

        return user;
    } 

    public void EditProfile(string name, string bio)
    {
        Name = name;
        Bio = bio;

        RaiseDomainEvent(new UserUpdatedDomainEvent(this));
    }

    public void UpdateEmail(string email)
    {
        Email = email;

        RaiseDomainEvent(new UserEmailUpdatedDomainEvent(this));
    }

    public void UpdatePassword(string passwordHash)
    {
        PasswordHash = passwordHash;

        RaiseDomainEvent(new UserPasswordUpdatedDomainEvent(this));
    }
}
