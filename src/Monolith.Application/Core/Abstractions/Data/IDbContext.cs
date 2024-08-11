using Microsoft.EntityFrameworkCore;
using Monolith.Domain.Core.BaseType;

namespace Monolith.Application.Core.Abstractions.Data;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
}
