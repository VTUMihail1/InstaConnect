using InstaConnect.Follows.Business.Features.Follows.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;

public record GetFollowByIdQuery(string Id) : IQuery<FollowQueryViewModel>;
