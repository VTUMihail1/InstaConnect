using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;

public class EmailConfirmationTokenOptions : IApplicationOptions
{
    public const string SectionName = "EmailConfirmationTokenConfiguration";

    [Required]
    public int LifetimeSeconds { get; set; }
}
