using InstaConnect.Shared.Common.Models.Enums;
using InstaConnect.Shared.Presentation.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetAllUsersRequest(
    [FromQuery(Name = "userName")] string UserName = "",
    [FromQuery(Name = "firstName")] string FirstName = "",
    [FromQuery(Name = "lastName")] string LastName = "",
    [FromQuery(Name = "sortOrder")] SortOrder SortOrder = SortOrder.ASC,
    [FromQuery(Name = "sortPropertyName")] string SortPropertyName = "CreatedAt",
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20
);
