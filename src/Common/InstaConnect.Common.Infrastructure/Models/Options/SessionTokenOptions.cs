using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Common.Infrastructure.Models.Options;

public class SessionTokenOptions
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
