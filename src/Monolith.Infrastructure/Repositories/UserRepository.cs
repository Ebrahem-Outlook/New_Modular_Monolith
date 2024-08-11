using Microsoft.EntityFrameworkCore;
using Monolith.Application.Core.Abstractions.Data;
using Monolith.Domain.Users;

namespace Monolith.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for managing <see cref="User"/> entities in the database.
    /// </summary>
    internal sealed class UserRepository : IUserRepository
    {
        private readonly IDbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context to interact with the database.</param>
        public UserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new <see cref="User"/> entity to the database.
        /// </summary>
        /// <param name="user">The user entity to add.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await dbContext.Set<User>().AddAsync(user, cancellationToken);
        }

        /// <summary>
        /// Updates an existing <see cref="User"/> entity in the database.
        /// </summary>
        /// <param name="user">The user entity to update.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateAsync(User user, CancellationToken cancellationToken)
        {
            dbContext.Set<User>().Update(user);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Deletes a <see cref="User"/> entity from the database.
        /// </summary>
        /// <param name="user">The user entity to delete.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task DeleteAsync(User user, CancellationToken cancellationToken)
        {
            dbContext.Set<User>().Remove(user);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Retrieves a paginated list of all <see cref="User"/> entities from the database.
        /// </summary>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of users to retrieve per page.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation that returns a list of users.</returns>
        public async Task<List<User>> GetAllUsersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .OrderBy(user => user.Id)
                                  .Skip((pageNumber - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its email address.
        /// </summary>
        /// <param name="email">The email address of the user to retrieve.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation that returns the user entity if found; otherwise, null.</returns>
        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(user => user.Email == email, cancellationToken);
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation that returns the user entity if found; otherwise, null.</returns>
        public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        /// <summary>
        /// Retrieves a <see cref="User"/> entity by its username.
        /// </summary>
        /// <param name="userName">The username of the user to retrieve.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation that returns the user entity if found; otherwise, null.</returns>
        public async Task<User?> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .SingleOrDefaultAsync(user => user.UserName == userName, cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of <see cref="User"/> entities by their name.
        /// </summary>
        /// <param name="name">The name of the users to retrieve.</param>
        /// <param name="cancellationToken">A token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation that returns a list of users with the specified name.</returns>
        public async Task<List<User>> GetUserByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await dbContext.Set<User>()
                                  .AsNoTracking()
                                  .Where(user => user.Name == name)
                                  .ToListAsync(cancellationToken);
        }
    }
}