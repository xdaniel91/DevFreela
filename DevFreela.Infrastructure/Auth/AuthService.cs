using DevFreela.Infrastructure.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DevFreela.Infrastructure.AuthService;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateJwtToken(string email, string role)
    {
        string? issuer = _configuration["Jwt:Issuer"];
        string? audience = _configuration["Jwt:Audience"];
        string? key = _configuration["Jwt:Key"];

        byte[]? keyBytes = Encoding.UTF8.GetBytes(key);

        var securityKey = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, email),
            new Claim(ClaimTypes.Role, role),
        };

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(12),
            signingCredentials: credentials);

        JwtSecurityTokenHandler tokenHandler = new();
        return tokenHandler.WriteToken(token);
    }
}
