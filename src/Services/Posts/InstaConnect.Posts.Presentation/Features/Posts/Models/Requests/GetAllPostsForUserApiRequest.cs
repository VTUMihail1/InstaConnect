using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetAllPostsForUserApiRequest(
    [FromRoute] string UserId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromQuery] string Title = PostDefaultValues.Title,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostsSortTerm SortTerm = PostDefaultValues.SortTerm,
    [FromQuery] int Page = PostDefaultValues.Page,
    [FromQuery] int PageSize = PostDefaultValues.PageSize) : ISortableApiRequest<PostsSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
