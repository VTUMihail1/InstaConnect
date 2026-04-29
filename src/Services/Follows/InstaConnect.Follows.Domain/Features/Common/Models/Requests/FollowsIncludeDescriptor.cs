using InstaConnect.Common.Domain.Features.Data.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Common.Models.Requests;

public record FollowsIncludeDescriptor(
	FollowsDestinationType DestinationType,
	FollowsIncludeType IncludeType)
	: IIncludeDescriptor<FollowsDestinationType, FollowsIncludeType>;
