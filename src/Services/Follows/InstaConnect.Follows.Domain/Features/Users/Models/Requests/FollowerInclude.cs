using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Models.Requests;

public record FollowerInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
    : IInclude<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>;
