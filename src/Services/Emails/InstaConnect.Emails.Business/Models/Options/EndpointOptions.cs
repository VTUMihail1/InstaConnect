using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Emails.Business.Models.Options;

public class EndpointOptions
{
    [Required]
    public string ConfirmEmail { get; set; } = string.Empty;

    [Required]
    public string ForgotPassword { get; set; } = string.Empty;
}
