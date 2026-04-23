using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Domain.Features.Users.Models.Requests;

public record FollowingInclude(ICollection<FollowsIncludeDescriptor> Descriptors)
    : IInclude<FollowsDestinationType, FollowsIncludeType, FollowsIncludeDescriptor>;
