using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monolith.Application.Core.Abstractions.Data;
using Monolith.Domain.Users;
using Monolith.Infrastructure.Database;
using Monolith.Infrastructure.Repositories;

namespace Monolith.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            string connection = configuration.GetConnectionString("Local-SqlServer") ?? throw new InvalidOperationException("ConnectionString does not exsit.....");

            options.UseSqlServer(connection);
        });

        services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());

        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<AppDbContext>());


        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
