using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowIncluderFactory
    : IIncluderFactory<FollowsIncludeType, FollowsDestinationType, FollowsIncludeDescriptor, IFollowIncluder, Follow>;

