namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public record GetFollowByIdQueryRequest(string FollowerId, string FollowingId) : IQueryRequest<GetFollowByIdQueryResponse>;
