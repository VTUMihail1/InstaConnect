using System.ComponentModel.DataAnnotations;

using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Options;

public class FollowOptions : IApplicationOptions
{
	public const string SectionName = "FollowConfiguration";

	[Required]
	public string HubRoute { get; set; } = string.Empty;
}
