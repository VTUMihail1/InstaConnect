using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.Posts.Queries.GetAllForUser;

public record GetAllPostsForUserQueryRequest(
    string UserId,
    string CurrentUserId,
    string Title,
    CommonSortOrder SortOrder,
    PostsForUserSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostsForUserQueryResponse>, ISortableQueryRequest<PostsForUserSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
