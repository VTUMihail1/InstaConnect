namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public record GetPostCommentByIdQueryRequest(string Id, string CommentId) : IQueryRequest<GetPostCommentByIdQueryResponse>;
