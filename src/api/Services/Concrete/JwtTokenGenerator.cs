using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Services.Interfaces;
using api.Settings;
using Microsoft.IdentityModel.Tokens;

namespace api.Services.Concrete;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwt;

    public JwtTokenGenerator(JwtSettings jwt)
    {
        _jwt = jwt;
    }

    public string GenerateToken(IEnumerable<Claim> claims)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            expires: DateTime.Now.AddMinutes(_jwt.ExpirationInMinutes),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
