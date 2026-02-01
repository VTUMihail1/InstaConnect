using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetAllPostLikesForUserApiRequest(
    [FromRoute] string UserId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostLikesSortTerm SortTerm = PostLikeDefaultValues.SortTerm,
    [FromQuery] int Page = PostLikeDefaultValues.Page,
    [FromQuery] int PageSize = PostLikeDefaultValues.PageSize) : ISortableApiRequest<PostLikesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
