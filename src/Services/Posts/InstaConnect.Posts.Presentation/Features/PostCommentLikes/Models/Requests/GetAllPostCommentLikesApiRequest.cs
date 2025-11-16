using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesApiRequest(
    [FromRoute] string Id,
    [FromRoute] string CommentId,
    [FromQuery] string UserName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostCommentLikeSortProperty SortProperty = PostCommentLikeDefaultValues.SortProperty,
    [FromQuery] int Page = PostCommentLikeDefaultValues.Page,
    [FromQuery] int PageSize = PostCommentLikeDefaultValues.PageSize);
