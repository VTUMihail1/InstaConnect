using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetAllPostLikesApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromRoute] string Id,
    [FromQuery] string UserName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostLikesSortTerm SortTerm = PostLikeDefaultValues.SortTerm,
    [FromQuery] int Page = PostLikeDefaultValues.Page,
    [FromQuery] int PageSize = PostLikeDefaultValues.PageSize) : ISortableApiRequest<PostLikesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
