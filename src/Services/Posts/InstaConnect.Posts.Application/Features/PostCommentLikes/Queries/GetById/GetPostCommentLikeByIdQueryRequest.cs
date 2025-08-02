using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetAll;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Queries.GetById;

public record GetPostCommentLikeByIdQueryRequest(string Id, string CommentId, string CommentLikeId) : IQueryRequest<GetPostCommentLikeByIdQueryResponse>;
