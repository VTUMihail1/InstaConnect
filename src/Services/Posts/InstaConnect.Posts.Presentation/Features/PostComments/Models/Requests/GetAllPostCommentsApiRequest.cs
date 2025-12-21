using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record GetAllPostCommentsApiRequest(
    [FromRoute] string Id,
    [FromQuery] string UserName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostCommentSortProperty SortProperty = PostCommentDefaultValues.SortProperty,
    [FromQuery] int Page = PostCommentDefaultValues.Page,
    [FromQuery] int PageSize = PostCommentDefaultValues.PageSize) : ISortableApiRequest<PostCommentSortProperty>, IPaginatableApiRequest;
