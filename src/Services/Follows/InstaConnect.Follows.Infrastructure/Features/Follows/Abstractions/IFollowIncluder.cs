using InstaConnect.Common.Infrastructure.Features.Databases.Abstractions;
using InstaConnect.Follows.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowIncluder : IIncluder<Follow, FollowsIncludeType, FollowsDestinationType>;
