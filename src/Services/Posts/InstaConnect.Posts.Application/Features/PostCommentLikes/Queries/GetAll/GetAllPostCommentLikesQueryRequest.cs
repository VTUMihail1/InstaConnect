namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQueryRequest(
    PostCommentLikeQueryFilter Filter,
    PostCommentLikeQuerySorting Sorting,
    PostCommentLikeQueryPagination Pagination)
    : IQueryRequest<GetAllPostCommentLikesQueryResponse>;
