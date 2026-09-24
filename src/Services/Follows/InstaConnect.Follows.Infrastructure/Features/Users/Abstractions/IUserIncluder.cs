using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, FollowsIncludeType, FollowsDestinationType>;
