using InstaConnect.Common.Domain.Features.Messaging.Models;
using InstaConnect.Posts.Application.Features.Users.Abstractions;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQueryRequest(
    string Id,
    string UserName,
    string CurrentUserId,
    CommonSortOrder SortOrder,
    PostCommentsSortTerm SortTerm,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostCommentsQueryResponse>, ISortableQueryRequest<PostCommentsSortTerm>, IPaginatableQueryRequest, ICurrentUserableQueryRequest;
