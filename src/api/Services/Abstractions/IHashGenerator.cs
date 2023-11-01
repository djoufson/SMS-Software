namespace api.Services.Abstractions;

/// <summary>
/// A service that generates hashes based on a string input
/// </summary>
public interface IHashGenerator
{
    /// <summary>
    /// Generates the hash of the specified input
    /// </summary>
    /// <param name="text">The text to hash</param>
    /// <returns>The generated hash</returns>
    string Hash(string text);
}
