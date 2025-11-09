namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record UserPaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
