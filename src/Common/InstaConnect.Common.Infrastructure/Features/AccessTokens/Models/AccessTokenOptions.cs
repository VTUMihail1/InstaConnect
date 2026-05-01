using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.AccessTokens.Models;

public class AccessTokenOptions : IApplicationOptions
{
	public const string SectionName = "AccessTokenConfiguration";

	[Required]
	public string Issuer { get; set; } = string.Empty;

	[Required]
	public string Audience { get; set; } = string.Empty;

	[Required]
	public string SecurityKey { get; set; } = string.Empty;

	[Required]
	public int LifetimeSeconds { get; set; } = 0;

	[Required]
	public bool ValidateIssuer { get; set; } = true;

	[Required]
	public bool ValidateAudience { get; set; } = true;

	[Required]
	public bool ValidateLifetime { get; set; } = true;

	[Required]
	public bool ValidateIssuerSigningKey { get; set; } = true;

	[Required]
	public int ClockSkewSeconds { get; set; } = 0;
}
