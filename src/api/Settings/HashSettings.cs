namespace api.Settings;

public sealed class HashSettings
{
    public static string SectionName => nameof(HashSettings);
    public string Salt { get; init; } = string.Empty;
}
