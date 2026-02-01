using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record GetAllPostCommentsForUserApiRequest(
    [FromRoute] string UserId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostCommentsSortTerm SortTerm = PostCommentDefaultValues.SortTerm,
    [FromQuery] int Page = PostCommentDefaultValues.Page,
    [FromQuery] int PageSize = PostCommentDefaultValues.PageSize) : ISortableApiRequest<PostCommentsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
