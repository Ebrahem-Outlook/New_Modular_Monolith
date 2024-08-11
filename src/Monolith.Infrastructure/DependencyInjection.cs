using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Monolith.Application.Core.Abstractions.Authentication;
using Monolith.Application.Core.Abstractions.Data;
using Monolith.Domain.Users;
using Monolith.Infrastructure.Authentication;
using Monolith.Infrastructure.Authentication.Settings;
using Monolith.Infrastructure.Database;
using Monolith.Infrastructure.Repositories;
using System.Text;

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


        // Add Authentication...
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]))
            });

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SettingsKey));

        services.AddScoped<IJwtProvider, JwtProvider>();


        return services;
    }
}
