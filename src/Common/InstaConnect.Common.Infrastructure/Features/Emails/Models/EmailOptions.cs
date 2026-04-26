using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Models;

public class EmailOptions : IApplicationOptions
{
    public const string SectionName = "EmailConfiguration";

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
