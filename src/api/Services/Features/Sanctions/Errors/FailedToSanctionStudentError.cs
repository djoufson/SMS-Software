using FluentResults;

namespace api.Services.Features.Sanctions.Errors;

public class FailedToSanctionStudentError : IError
{
    public List<IError> Reasons => new();

    public string Message => "The sanction operation failed unexpectedly";

    public Dictionary<string, object> Metadata => new();
}
