namespace api.Settings;

public sealed class JwtSettings
{
    public static string SectionName => nameof(JwtSettings);
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpirationInMinutes { get; set; }
    public string SecretKey { get; set; } = string.Empty;
}
