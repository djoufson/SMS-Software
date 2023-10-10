using api.Entities.ValueObjects;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Features.Users;

public partial class UserService
{
    public async Task<Result<DeleteUserResponse>> DeleteUser(DeleteUserCommand request)
    {
        var email = Email.Create(request.UserEmail);
        int records = await _context.Users
            .Where(u => u.Email == email)
            .ExecuteDeleteAsync();

        return new DeleteUserResponse(records);
    }
}

public record DeleteUserResponse(
    int Records
);

public record DeleteUserCommand(
    string UserEmail
);
