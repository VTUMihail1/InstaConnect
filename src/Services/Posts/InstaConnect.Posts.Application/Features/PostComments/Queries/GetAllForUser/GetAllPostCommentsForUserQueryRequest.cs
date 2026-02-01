using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAllForUser;

public record GetAllPostCommentsForUserQueryRequest(
    string UserId,
    string CurrentUserId,
    CommonSortOrder SortOrder,
    PostCommentsSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostCommentsForUserQueryResponse>, ISortableQueryRequest<PostCommentsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
