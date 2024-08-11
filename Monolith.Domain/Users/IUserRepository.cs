namespace Monolith.Domain.Users;

public interface IUserRepository
{
    // Commands.
    Task AddAsync(User user, CancellationToken cancellation);
    Task UpdateAsync(User user, CancellationToken cancellation);
    Task DeleteAsync(User user, CancellationToken cancellation);

    // Queries.
    Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<User?> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    Task<List<User>> GetUserByNameAsync(string name, CancellationToken cancellationToken);
}
