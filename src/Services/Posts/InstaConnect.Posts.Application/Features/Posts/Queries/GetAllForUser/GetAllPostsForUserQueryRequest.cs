using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;

public record GetAllPostsForUserQueryRequest(
    string UserId,
    string CurrentUserId,
    string Title,
    CommonSortOrder SortOrder,
    PostsSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostsForUserQueryResponse>, ISortableQueryRequest<PostsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
