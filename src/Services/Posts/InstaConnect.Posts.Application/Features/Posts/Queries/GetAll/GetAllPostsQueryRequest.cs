namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsQueryRequest(
    PostQueryFilter Filter,
    PostQuerySorting Sorting,
    PostQueryPagination Pagination)
    : IQueryRequest<GetAllPostsQueryResponse>;
