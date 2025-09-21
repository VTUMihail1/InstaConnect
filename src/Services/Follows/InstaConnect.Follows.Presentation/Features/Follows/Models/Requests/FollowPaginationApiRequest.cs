namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public record FollowPaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
