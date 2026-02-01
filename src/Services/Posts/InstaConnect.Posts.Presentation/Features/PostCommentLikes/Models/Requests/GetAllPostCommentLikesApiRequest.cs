using System.Security.Claims;

using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Abstractions;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromQuery] string UserName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostCommentLikesSortTerm SortTerm = PostCommentLikeDefaultValues.SortTerm,
    [FromQuery] int Page = PostCommentLikeDefaultValues.Page,
    [FromQuery] int PageSize = PostCommentLikeDefaultValues.PageSize) : ISortableApiRequest<PostCommentLikesSortTerm>, IPaginatableApiRequest, ICurrentUserableApiRequest;
