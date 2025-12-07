using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;

public record GetAllPostsQueryRequest(
    string UserId,
    string UserName,
    string Title,
    CommonSortOrder SortOrder,
    PostSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostsQueryResponse>;
