using api.Entities.Base;

namespace api.Entities.ValueObjects;

public sealed record Password : ValueObject
{
    public override string Value { get; protected set; }

    private Password(string hash)
    {
        Value = hash;
    }

    public static Password? CreateNewPassword(string password)
    {
        if (ValidatePassword(password))
            return new(HashPassword(password));

        return null;
    }

    public static Password CreateFromHash(string hash)
    {
        return new(hash);
    }

    private static bool ValidatePassword(string password)
    {
        return
            !string.IsNullOrEmpty(password) &&
            password.Length >= 6;
    }

    private static string HashPassword(string password)
    {
        return password;
    }
}
