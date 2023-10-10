using System.Security.Claims;
using api.Entities.ValueObjects;
using api.Services.Features.Authentication.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Features.Authentication;

public partial class AuthService
{
    public async Task<Result<LoginResponse>> Login(LoginRequest request, CancellationToken cancellationToken = default)
    {
        // Get the user with specified email
        var email = Email.Create(request.Email);
        var user = await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        if(user is null)
            return Result.Fail(AuthErrors.UserNotFoundError);

        // Check the password
        var password = Password.CreateNewPassword(request.Password);
        if(user.Password != password)
            return Result.Fail(AuthErrors.BadCredentialsError);

        // Generate token
        var claims = new List<Claim>()
        {
            new (ClaimTypes.NameIdentifier, user.Id)
        };

        if(user.Roles.Any())
            claims.AddRange(user.Roles.Select(r => new Claim(ClaimTypes.Role, r.Designation)));

        var token = _tokenGenerator.GenerateToken(claims);
        return new LoginResponse(token);
    }
}

public record LoginResponse(
    string Token
);
public record LoginRequest(
    string Email,
    string Password
);
