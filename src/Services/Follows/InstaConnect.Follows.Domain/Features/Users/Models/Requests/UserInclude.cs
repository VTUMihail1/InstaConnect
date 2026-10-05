using InstaConnect.Common.Domain.Features.Databases.Models;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
	: Include<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>(Descriptors);
