using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;

public record GetPostCommentByIdQueryRequest(
    string Id,
    string CommentId) : IQueryRequest<GetPostCommentByIdQueryResponse>;
