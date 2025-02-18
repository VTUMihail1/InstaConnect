namespace InstaConnect.Shared.Infrastructure.Models.Options;

public class AccessTokenOptions
{
    [Required]
    public string Issuer { get; set; } = string.Empty;

    [Required]
    public string Audience { get; set; } = string.Empty;

    [Required]
    public string SecurityKey { get; set; } = string.Empty;

    [Required]
    public int LifetimeSeconds { get; set; } = 0;
}
