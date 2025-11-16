using InstaConnect.Common.Domain.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Presentation.Features.Users.Utilities;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record GetAllPostsApiRequest(
    [FromQuery(Name = "userId")] string UserId = UserDefaultValues.Id,
    [FromQuery(Name = "userName")] string UserName = UserDefaultValues.Name,
    [FromQuery(Name = "title")] string Title = PostDefaultValues.Title,
    [FromQuery(Name = "sortOrder")] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery(Name = "sortProperty")] PostSortProperty SortProperty = PostDefaultValues.SortProperty,
    [FromQuery(Name = "page")] int Page = PostDefaultValues.Page,
    [FromQuery(Name = "pageSize")] int PageSize = PostDefaultValues.PageSize);

