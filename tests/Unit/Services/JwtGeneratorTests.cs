using System.Security.Claims;
using api.Services.Concrete;
using api.Settings;

namespace tests.Unit.Services;

public class JwtGeneratorTests
{
    private readonly JwtSettings _jwtSettings;
    public JwtGeneratorTests()
    {
        _jwtSettings = new JwtSettings()
        {
            Issuer = "SMS.Api",
            Audience = "SMS.Client",
            ExpirationInMinutes = 30,
            SecretKey = "super-secret-key"
        };
    }

    [Theory]
    [InlineData("admin@email.com", "admin@email.com", true)]
    [InlineData("admin@emaisl.com", "admin@email.com", false)]
    [InlineData("admin@emaiL.com", "admin@email.com", false)]
    public void JwtTokens_ShouldNeverBeTheSameForDifferentInputs(string firstValue, string secondValue, bool expected)
    {
        // Arrange
        var jwt = new JwtTokenGenerator(_jwtSettings);
        var firstClaims = new[]
        {
            new Claim(ClaimTypes.Email, firstValue)
        };

        var secondClaims = new[]
        {
            new Claim(ClaimTypes.Email, secondValue)
        };

        // Act
        var firstToken = jwt.GenerateToken(firstClaims);
        var secondToken = jwt.GenerateToken(secondClaims);

        // Assert
        Assert.Equal(expected, firstToken == secondToken);
    }

    [Fact]
    public void JwtTokens_ShouldNeverBeTheSameWhenGeneratedAtDifferentTime()
    {
        // Arrange
        var jwt = new JwtTokenGenerator(_jwtSettings);
        var firstClaims = new[]
        {
            new Claim(ClaimTypes.Name, "firstValue")
        };

        var secondClaims = new[]
        {
            new Claim(ClaimTypes.Name, "secondValue")
        };

        // Act
        var firstToken = jwt.GenerateToken(firstClaims);
        Thread.Sleep(1000);
        var secondToken = jwt.GenerateToken(secondClaims);

        // Assert
        Assert.NotEqual(firstToken, secondToken);
    }
}
