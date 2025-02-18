namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public record GetPostCommentByIdQuery(string Id) : IQuery<PostCommentQueryViewModel>;
