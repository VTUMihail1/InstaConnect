using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Emails.Models;

public class SendGridOptions : IApplicationOptions
{
	public const string SectionName = "SendGridConfiguration";

	[Required]
	public string Sender { get; set; } = string.Empty;

	[Required]
	public string ApiKey { get; set; } = string.Empty;
}
