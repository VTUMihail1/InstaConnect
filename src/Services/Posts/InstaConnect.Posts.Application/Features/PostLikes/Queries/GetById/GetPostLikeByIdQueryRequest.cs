namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public record GetPostLikeByIdQueryRequest(string Id, string UserId) : IQueryRequest<GetPostLikeByIdQueryResponse>;
