namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAll;

public record GetAllPostCommentLikesQueryRequest(
    PostCommentLikeFilterQueryRequest Filter,
    PostCommentLikeSortingQueryRequest Sorting,
    PostCommentLikePaginationQueryRequest Pagination)
    : IQueryRequest<GetAllPostCommentLikesQueryResponse>;
