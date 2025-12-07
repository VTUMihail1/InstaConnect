using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetAllPostsApiRequest(
    [FromQuery] string UserId = UserDefaultValues.Id,
    [FromQuery] string UserName = UserDefaultValues.Name,
    [FromQuery] string Title = PostDefaultValues.Title,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] PostSortProperty SortProperty = PostDefaultValues.SortProperty,
    [FromQuery] int Page = PostDefaultValues.Page,
    [FromQuery] int PageSize = PostDefaultValues.PageSize);

