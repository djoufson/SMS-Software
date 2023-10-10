using api.Entities.Base;

namespace api.Entities.ValueObjects;

public sealed record Email : ValueObject
{
    public override string Value { get; protected set; }
    private Email(string email)
    {
        Value = email;
    }

    public static Email? Create(string email)
    {
        if(ValidateEmail(email))
            return new(email);
        return null;
    }

    private static bool ValidateEmail(string email)
    {
        return !string.IsNullOrEmpty(email);
    }
}
