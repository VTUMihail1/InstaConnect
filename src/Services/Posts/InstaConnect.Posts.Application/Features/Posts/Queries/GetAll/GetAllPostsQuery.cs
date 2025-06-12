using InstaConnect.Common.Application.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsQuery(
    PostQueryFilter Filter,
    PostQuerySorting Sorting,
    PostQueryPagination Pagination)
    : IQuery<GetAllPostsQueryResponse>;
