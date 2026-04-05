using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

public class RefreshTokenOptions
{
    public const string SectionName = "RefreshTokenConfiguration";

    [Required]
    public int LifetimeSeconds { get; set; }
}
