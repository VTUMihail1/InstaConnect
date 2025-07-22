namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public record GetPostCommentLikeByIdQuery(string Id, string PostId, string PostCommentId) : IQueryRequest<PostCommentLikeQueryViewModel>;
