using FluentResults;

namespace api.Services.Features.Authentication.Errors;

public class PasswordRequirementsError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The password does not match the required pattern";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
