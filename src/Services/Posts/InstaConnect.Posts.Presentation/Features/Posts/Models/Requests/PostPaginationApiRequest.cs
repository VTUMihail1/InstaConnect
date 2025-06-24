namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record PostPaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
