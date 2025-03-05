namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public record GetPostCommentByIdQuery(string Id, string PostId) : IQuery<PostCommentQueryViewModel>;
