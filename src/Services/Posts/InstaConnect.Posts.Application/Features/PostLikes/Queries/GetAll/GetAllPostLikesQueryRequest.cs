namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAll;

public record GetAllPostLikesQueryRequest(
    PostLikeFilterQueryRequest Filter,
    PostLikeSortingQueryRequest Sorting,
    PostLikePaginationQueryRequest Pagination)
    : IQueryRequest<GetAllPostLikesQueryResponse>;
