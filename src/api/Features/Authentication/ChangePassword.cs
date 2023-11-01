using api.Entities.ValueObjects;
using api.Features.Authentication.Errors;
using FluentResults;

namespace api.Features.Authentication;

public partial class AuthService
{
    public async Task<Result<ChangePasswordResponse>> ChangePassword(ChangePasswordCommand request)
    {
        // Get the user by its Id
        var user = await _context.Users.FindAsync(request.UserId);
        if(user is null)
            return Result.Fail(AuthErrors.UserNotFoundError);

        var password = Password.CreateNewPassword(request.Password, _hashGenerator);
        if(user.Password != password)
            return Result.Fail(AuthErrors.MismatchPasswordError);

        // Update his password
        var newPassword = Password.CreateNewPassword(request.NewPassword, _hashGenerator);
        if(newPassword is null)
            return Result.Fail(AuthErrors.PasswordRequirementsError);
        user.ChangePassword(newPassword);

        // Save the changes
        await _context.SaveChangesAsync();
        return new ChangePasswordResponse(true);
    }
}

public record ChangePasswordResponse(
    bool Success
);

public record ChangePasswordCommand(
    string UserId,
    string Password,
    string NewPassword
);

public record ChangePasswordRequest(
    string Password,
    string NewPassword);
