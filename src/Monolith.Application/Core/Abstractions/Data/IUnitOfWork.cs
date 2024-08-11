using Microsoft.EntityFrameworkCore.Storage;

namespace Monolith.Application.Core.Abstractions.Data;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    Task<IDbContextTransaction> BeginTransaction(CancellationToken cancellationToken);
}
