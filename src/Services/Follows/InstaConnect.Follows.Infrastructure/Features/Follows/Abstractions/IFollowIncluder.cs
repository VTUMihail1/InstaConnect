using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowIncluder : IIncluder<Follow, FollowsIncludeType, FollowsDestinationType>;
