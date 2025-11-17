namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsQueryRequest(
    PostFilterQueryRequest Filter,
    PostSortingQueryRequest Sorting,
    PostPaginationQueryRequest Pagination)
    : IQueryRequest<GetAllPostsQueryResponse>;
