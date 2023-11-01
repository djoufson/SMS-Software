using FluentResults;

namespace api.Features.Authentication.Errors;

public sealed class BadCredentialsError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The credentials you entered are not valid";

    public Dictionary<string, object> Metadata => new();
}
