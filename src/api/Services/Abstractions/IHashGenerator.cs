namespace api.Services.Abstractions;

public interface IHashGenerator
{
    string Hash(string text);
}
