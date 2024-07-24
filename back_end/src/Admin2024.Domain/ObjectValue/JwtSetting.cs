namespace Admin2024.Domain.ObjectValue;

public class JwtSetting
{
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
    public int ExpirationMinutes { get; set; }
}