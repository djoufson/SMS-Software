using System.Security.Claims;

namespace api.Services.Abstractions;

public interface IJwtTokenGenerator
{
    string GenerateToken(IEnumerable<Claim> claims);
}
