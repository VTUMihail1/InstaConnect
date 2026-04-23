using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

internal interface IFollowIncluder : IIncluder<Follow, FollowsIncludeType, FollowsDestinationType>;
