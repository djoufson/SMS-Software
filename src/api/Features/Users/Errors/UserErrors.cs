namespace api.Features.Users.Errors;

public sealed class UserErrors
{
    public static ConflictedEmailsError ConflictedEmailsError => new();
    public static UserRegistrationError UserRegistrationError => new();
}
