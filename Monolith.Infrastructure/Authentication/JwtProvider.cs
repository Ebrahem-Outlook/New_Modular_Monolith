using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Monolith.Application.Core.Abstractions.Authentication;
using Monolith.Domain.Users;
using Monolith.Infrastructure.Authentication.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Monolith.Infrastructure.Authentication;

internal sealed class JwtProvider : IJwtProvider
{
    private readonly JwtSettings _jwtSettings;

    public JwtProvider(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));

        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        Claim[] claims =
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("userName", user.UserName)
        };

        DateTime tokenExpirationTime = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes);

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            null,
            tokenExpirationTime,
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}
