using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsQueryRequest(
    string UserName,
    string Title,
    CommonSortOrder SortOrder,
    PostSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostsQueryResponse>, ISortableQueryRequest<PostSortProperty>, IPaginatableQueryRequest;
