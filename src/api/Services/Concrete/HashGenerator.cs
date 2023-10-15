using System.Security.Cryptography;
using System.Text;
using api.Services.Abstractions;
using api.Settings;

namespace api.Services.Concrete;

public class HashGenerator : IHashGenerator
{
    private readonly HashSettings _hashSettings;

    public HashGenerator(HashSettings hashSettings)
    {
        _hashSettings = hashSettings;
    }

    public string Hash(string text)
    {
        byte[] saltBytes = Encoding.UTF8.GetBytes(_hashSettings.Salt);
        byte[] dataBytes = Encoding.UTF8.GetBytes(text);

        byte[] combinedBytes = new byte[saltBytes.Length + dataBytes.Length];
        Array.Copy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
        Array.Copy(dataBytes, 0, combinedBytes, 0, dataBytes.Length);
        byte[] hashedBytes = SHA512.HashData(combinedBytes);
        return Convert.ToBase64String(hashedBytes);
    }
}
