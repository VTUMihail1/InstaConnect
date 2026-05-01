using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Common.Infrastructure.Features.Images.Models;

public class CloudinaryOptions : IApplicationOptions
{
	public const string SectionName = "CloudinaryConfiguration";

	[Required]
	public string CloudName { get; set; } = string.Empty;

	[Required]
	public string ApiKey { get; set; } = string.Empty;

	[Required]
	public string ApiSecret { get; set; } = string.Empty;
}
