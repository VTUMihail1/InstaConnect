using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesForUserApiRequest(
    [FromRoute] string UserId,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostCommentLikesSortTerm SortTerm = PostCommentLikeDefaultValues.SortTerm,
    [FromQuery] int Page = PostCommentLikeDefaultValues.Page,
    [FromQuery] int PageSize = PostCommentLikeDefaultValues.PageSize) : ISortableApiRequest<PostCommentLikesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
