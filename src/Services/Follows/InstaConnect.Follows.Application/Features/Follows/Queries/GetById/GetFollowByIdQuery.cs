namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public record GetFollowByIdQuery(string Id) : IQueryRequest<FollowQueryViewModel>;
