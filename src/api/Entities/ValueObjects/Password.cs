using api.Entities.Base;
using api.Services.Interfaces;

namespace api.Entities.ValueObjects;

public sealed record Password : ValueObject
{
    public override string Value { get; protected set; }

    private Password(string hash)
    {
        Value = hash;
    }

    public static Password? CreateNewPassword(string password, IHashGenerator hashGenerator)
    {
        if (ValidatePassword(password))
            return new(hashGenerator.Hash(password));

        return null;
    }

    public static Password CreateFromHash(string hash)
    {
        return new(hash);
    }

    private static bool ValidatePassword(string password)
    {
        return
            !string.IsNullOrEmpty(password); // &&
            // password.Length >= 6;
    }
}
