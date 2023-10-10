using FluentResults;

namespace api.Services.Features.Users.Errors;

public sealed class ConflictedEmailsError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The email you tried to use is already registered in our system";

    public Dictionary<string, object> Metadata => new();
}
