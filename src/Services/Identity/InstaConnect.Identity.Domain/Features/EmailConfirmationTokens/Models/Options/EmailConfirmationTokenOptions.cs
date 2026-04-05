using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;

public class EmailConfirmationTokenOptions
{
    public const string SectionName = "EmailConfirmationTokenConfiguration";

    [Required]
    public int LifetimeSeconds { get; set; }
}
