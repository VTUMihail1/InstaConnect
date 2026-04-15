namespace InstaConnect.Follows.Domain.Models.Requests;

public record FollowsIncludeDescriptor(
    FollowsDestinationType DestinationType,
    FollowsIncludeType IncludeType)
    : IIncludeDescriptor<FollowsDestinationType, FollowsIncludeType>;
