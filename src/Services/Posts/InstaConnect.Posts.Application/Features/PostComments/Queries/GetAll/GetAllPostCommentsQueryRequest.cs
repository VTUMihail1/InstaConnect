using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Application.Features.PostComments.Queries.GetAll;

public record GetAllPostCommentsQueryRequest(
    string Id,
    string UserId,
    string UserName,
    CommonSortOrder SortOrder,
    PostCommentSortProperty SortProperty,
    int Page,
    int PageSize)
    : IQueryRequest<GetAllPostCommentsQueryResponse>;
