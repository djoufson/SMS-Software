using System.Security.Claims;

namespace api.Services.Interfaces;

/// <summary>
/// A service used to generate JWT Bearer Tokens
/// </summary>
public interface IJwtTokenGenerator
{
    /// <summary>
    /// Generates a token based on a collection of claims
    /// </summary>
    /// <param name="claims">The collection of claims to generate the token based on</param>
    /// <returns>The generated token</returns>
    string GenerateToken(IEnumerable<Claim> claims);
}
