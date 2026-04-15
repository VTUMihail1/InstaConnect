using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public record GetPostLikeByIdQueryRequest(
    string Id,
    string UserId,
    string CurrentUserId) : IQueryRequest<GetPostLikeByIdQueryResponse>, ICurrentUserableQueryRequest;
