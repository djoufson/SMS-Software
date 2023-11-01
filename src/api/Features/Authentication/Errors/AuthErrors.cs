namespace api.Features.Authentication.Errors;

public class AuthErrors
{
    public static BadCredentialsError BadCredentialsError => new();
    public static MismatchPasswordError MismatchPasswordError => new();
    public static PasswordRequirementsError PasswordRequirementsError => new();
    public static UserNotFoundError UserNotFoundError => new();
}
