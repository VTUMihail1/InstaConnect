using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

public class ForgotPasswordTokenOptions
{
    public const string SectionName = "ForgotPasswordTokenConfiguration";

    [Required]
    public int LifetimeSeconds { get; set; }
}
