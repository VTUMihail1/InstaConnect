using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Identity.Infrastructure.Features.Common.Models.Options;

public class AdminOptions : IApplicationOptions
{
	public const string SectionName = "AdminConfiguration";

	[Required]
	public string Name { get; set; } = string.Empty;

	[Required]
	public string Email { get; set; } = string.Empty;

	[Required]
	public string FirstName { get; set; } = string.Empty;

	[Required]
	public string LastName { get; set; } = string.Empty;

	[Required]
	public string Password { get; set; } = string.Empty;
}
