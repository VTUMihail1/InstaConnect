using InstaConnect.Common.Domain.Models;
using InstaConnect.Identity.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetAllUsersApiRequest(
    [FromQuery] string FirstName = UserDefaultValues.FirstName,
    [FromQuery] string LastName = UserDefaultValues.LastName,
    [FromQuery] string Name = UserDefaultValues.Name,
    [FromQuery] CommonSortOrder SortOrder = CommonDefaultValues.SortOrder,
    [FromQuery] UserSortProperty SortProperty = UserDefaultValues.SortProperty,
    [FromQuery] int Page = UserDefaultValues.Page,
    [FromQuery] int PageSize = UserDefaultValues.PageSize);
