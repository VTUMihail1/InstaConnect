using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Options;

public class ForgotPasswordOptions
{
    [Required]
    public int LifetimeSeconds { get; set; } = 0;

    [Required]
    public string UrlTemplate { get; set; } = string.Empty;
}
