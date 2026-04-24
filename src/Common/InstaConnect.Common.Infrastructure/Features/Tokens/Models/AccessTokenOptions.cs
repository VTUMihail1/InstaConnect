using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Tokens.Models;

public class AccessTokenOptions : IApplicationOptions
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
