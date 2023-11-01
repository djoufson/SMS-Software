using FluentResults;

namespace api.Features.Authentication.Errors;

public sealed class UserNotFoundError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The requested user does not exist";

    public Dictionary<string, object> Metadata => new();
}
