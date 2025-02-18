namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public record GetPostCommentLikeByIdQuery(string Id) : IQuery<PostCommentLikeQueryViewModel>;
