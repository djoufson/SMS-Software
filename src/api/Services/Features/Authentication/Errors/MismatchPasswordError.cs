using FluentResults;

namespace api.Services.Features.Authentication.Errors;

public class MismatchPasswordError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The supplied password does not match your actual password";

    public Dictionary<string, object> Metadata => new();
}
