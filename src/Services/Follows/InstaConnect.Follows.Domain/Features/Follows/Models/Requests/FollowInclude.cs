using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record FollowInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
    : IInclude<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>;
