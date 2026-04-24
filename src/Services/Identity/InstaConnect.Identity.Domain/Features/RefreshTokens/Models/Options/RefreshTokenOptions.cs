using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

public class RefreshTokenOptions : IApplicationOptions
{
    public const string SectionName = "RefreshTokenConfiguration";

    [Required]
    public int LifetimeSeconds { get; set; }
}
