namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetById;

public record GetPostCommentByIdQueryRequest(PostCommentIdPayload Id) : IQueryRequest<GetPostCommentByIdQueryResponse>;
