using api.Entities.ValueObjects;
using api.Services.Features.Authentication.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Features.Authentication;

public partial class AuthService
{
    public async Task<Result<ResetPasswordResponse>> ResetPassword(ResetPasswordCommand request)
    {
        // Get the requested user
        var email = Email.Create(request.UserEmail);
        var student = await _context.Students.FirstOrDefaultAsync(u => u.Email == email);
        if(student is null)
            return Result.Fail(AuthErrors.UserNotFoundError);

        // Update his password
        var password = Password.CreateNewPassword(request.Password, _hashGenerator);
        if(password is null)
            return Result.Fail(AuthErrors.PasswordRequirementsError);

        student.ChangePassword(password);
        await _context.SaveChangesAsync();
        return new ResetPasswordResponse(true);
    }
}

public record ResetPasswordRequest(
    string Password);
public record ResetPasswordResponse(
    bool Status
);
public record ResetPasswordCommand(
    string UserEmail,
    string Password
);
