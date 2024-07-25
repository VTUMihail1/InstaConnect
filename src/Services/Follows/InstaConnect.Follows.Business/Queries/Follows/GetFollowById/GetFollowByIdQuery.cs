using InstaConnect.Follows.Business.Models.Follows;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Follows.Read.Business.Queries.Follows.GetFollowById;

public record GetFollowByIdQuery(string Id) : IQuery<FollowQueryViewModel>;
