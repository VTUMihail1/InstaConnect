using InstaConnect.Common.Domain.Features.Databases.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Common.Models.Requests;

public record FollowsIncludeDescriptor(
	FollowsDestinationType DestinationType,
	FollowsIncludeType IncludeType)
	: IIncludeDescriptor<FollowsDestinationType, FollowsIncludeType>;
