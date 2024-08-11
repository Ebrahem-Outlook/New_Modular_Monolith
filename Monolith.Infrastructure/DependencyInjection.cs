using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monolith.Infrastructure.Database;

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

        return services;
    }
}
