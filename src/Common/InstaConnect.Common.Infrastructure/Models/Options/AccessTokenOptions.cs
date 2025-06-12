using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class AccessTokenOptions
{
    public const string SectionName = "AccessTokenConfiguration";

    [Required]
    public string Issuer { get; set; } = string.Empty;

    [Required]
    public string Audience { get; set; } = string.Empty;

    [Required]
    public string SecurityKey { get; set; } = string.Empty;

    [Required]
    public int LifetimeSeconds { get; set; } = 0;
}
