using FluentResults;

namespace api.Services.Features.Users.Errors;

public class UserRegistrationError : IError
{
    public List<IError> Reasons => new();

    public string Message => "An unexpected error ocurred while attempting to proceed your request";

    public Dictionary<string, object> Metadata => new();
}
