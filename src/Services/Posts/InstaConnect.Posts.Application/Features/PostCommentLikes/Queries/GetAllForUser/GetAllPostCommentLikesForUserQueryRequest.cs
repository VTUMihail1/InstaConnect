using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Queries.GetAllForUser;

public record GetAllPostCommentLikesForUserQueryRequest(
    string UserId,
    string CurrentUserId,
    CommonSortOrder SortOrder,
    PostCommentLikesSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostCommentLikesForUserQueryResponse>, ISortableQueryRequest<PostCommentLikesSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
