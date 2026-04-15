using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowIncluderFactory
    : IIncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IFollowIncluder, Follow>;

