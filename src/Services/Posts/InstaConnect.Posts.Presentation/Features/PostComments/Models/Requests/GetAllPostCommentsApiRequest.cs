using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record GetAllPostCommentsApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromRoute] string Id,
    [FromQuery] string UserName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostCommentsSortTerm SortTerm = PostCommentDefaultValues.SortTerm,
    [FromQuery] int Page = PostCommentDefaultValues.Page,
    [FromQuery] int PageSize = PostCommentDefaultValues.PageSize) : ISortableApiRequest<PostCommentsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
