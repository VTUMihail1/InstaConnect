using InstaConnect.Follows.Application.Features.Users.Abstractions;

namespace InstaConnect.Follows.Application.Features.Follows.Queries.GetById;

public record GetFollowByIdQueryRequest(
	string FollowerId,
	string FollowingId,
	string CurrentUserId) : IQueryRequest<GetFollowByIdQueryResponse>, ICurrentUserableQueryRequest;
