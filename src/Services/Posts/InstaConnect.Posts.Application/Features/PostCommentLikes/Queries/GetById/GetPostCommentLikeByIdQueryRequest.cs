namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetById;

public record GetPostCommentLikeByIdQueryRequest(PostCommentLikeIdPayload Id) : IQueryRequest<GetPostCommentLikeByIdQueryResponse>;
