using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetAllForUser;

public record GetAllPostLikesForUserQueryRequest(
    string UserId,
    string CurrentUserId,
    CommonSortOrder SortOrder,
    PostLikesSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostLikesForUserQueryResponse>, ISortableQueryRequest<PostLikesSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
