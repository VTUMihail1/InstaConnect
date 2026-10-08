using InstaConnect.Common.Domain.Features.Databases.Models;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowFollowerInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: Include<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>(Descriptors);
