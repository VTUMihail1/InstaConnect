namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

public record GetPostLikeByIdQueryRequest(string Id, string PostId) : IQueryRequest<PostLikeQueryViewModel>;
