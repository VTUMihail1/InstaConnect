using InstaConnect.Follows.Application.Features.Follows.Models;
using InstaConnect.Shared.Application.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetFollowById;

public record GetFollowByIdQuery(string Id) : IQuery<FollowQueryViewModel>;
