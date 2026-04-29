using InstaConnect.Common.Domain.Features.Data.Abstractions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Models.Requests;

public record FollowerInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: IInclude<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>;
