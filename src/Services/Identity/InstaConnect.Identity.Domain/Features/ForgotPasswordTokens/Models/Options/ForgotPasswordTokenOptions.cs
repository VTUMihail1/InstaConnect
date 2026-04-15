using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

public class ForgotPasswordTokenOptions : IApplicationOptions
{
    public const string SectionName = "ForgotPasswordTokenConfiguration";

    [Required]
    public int LifetimeSeconds { get; set; }
}
