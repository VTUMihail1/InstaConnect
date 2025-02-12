using System.ComponentModel.DataAnnotations;

namespace InstaConnect.Emails.Infrastructure.Features.Emails.Models.Options;

public class EmailOptions
{
    [Required]
    public string SmtpServer { get; set; } = string.Empty;

    [Required]
    public int Port { get; set; } = default;

    [Required]
    public string Sender { get; set; } = string.Empty;

    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}
