using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetAllPostLikesApiRequest(
    [FromRoute] string Id,
    [FromQuery] string UserName = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostLikeSortProperty SortProperty = PostLikeDefaultValues.SortProperty,
    [FromQuery] int Page = PostLikeDefaultValues.Page,
    [FromQuery] int PageSize = PostLikeDefaultValues.PageSize) : ISortableApiRequest<PostLikeSortProperty>, IPaginatableApiRequest;
