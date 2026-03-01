using InstaConnect.Follows.Domain.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, FollowsIncludeType, FollowsDestinationType>;
