namespace Monolith.Domain.Users;

public interface IUserRepository
{
    // Commands.
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
    Task DeleteAsync(User user, CancellationToken cancellationToken);

    // Queries.
    Task<List<User>> GetAllUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<User?> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken);
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    Task<List<User>> GetUserByNameAsync(string name, CancellationToken cancellationToken);
}
