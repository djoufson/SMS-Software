using api.Entities;
using api.Entities.ValueObjects;
using api.Services.Features.Authentication.Errors;
using api.Services.Features.Sanctions.Errors;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Features.Sanctions;

public partial class SanctionService
{
    public async Task<Result<SanctionResponse>> SanctionStudent(SanctionCommand request)
    {
        // Get the student from the db
        var studentEmail = Email.Create(request.StudentEmail);
        var student = await _context.Students.FirstOrDefaultAsync(s => s.Email == studentEmail);
        if(student is null)
            return Result.Fail(AuthErrors.UserNotFoundError);

        var secretary = await _context.Secretaries.FindAsync(request.SecretaryId);
        if(secretary is null)
            return Result.Fail(AuthErrors.UserNotFoundError);

        // Create a sanction
        var sanction = Sanction.Create(secretary, student, request.Motif, request.Amount);

        // Assign that sanction to a student
        bool success = secretary.SanctionStudent(student, sanction);
        if(!success)
            return Result.Fail(SanctionErrors.FailedToSanctionStudentError);

        await _context.SaveChangesAsync();

        return new SanctionResponse(
            sanction.Id,
            student.Id,
            secretary.Id,
            sanction.Motif,
            sanction.Amount,
            sanction.PaidStatus
        );
    }
}

public record SanctionCommand(
    string SecretaryId,
    string StudentEmail,
    string Motif,
    decimal Amount
);

public record SanctionRequest(
    string StudentEmail,
    string Motif,
    decimal Amount);
