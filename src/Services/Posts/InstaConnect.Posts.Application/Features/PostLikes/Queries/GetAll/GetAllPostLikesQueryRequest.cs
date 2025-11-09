namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryRequest(
    PostLikeQueryFilter Filter,
    PostLikeQuerySorting Sorting,
    PostLikeQueryPagination Pagination)
    : IQueryRequest<GetAllPostLikesQueryResponse>;
