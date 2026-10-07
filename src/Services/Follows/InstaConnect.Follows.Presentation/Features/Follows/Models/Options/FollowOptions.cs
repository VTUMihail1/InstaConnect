using InstaConnect.Common.Domain.Features.Common.Abstractions;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Options;

public record FollowOptions(
	string HubRoute) : IApplicationOptions
{
	public const string SectionName = "FollowConfiguration";
}
