namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public record GetFollowByIdQueryRequest(FollowIdPayload Id) : IQueryRequest<GetFollowByIdQueryResponse>;
