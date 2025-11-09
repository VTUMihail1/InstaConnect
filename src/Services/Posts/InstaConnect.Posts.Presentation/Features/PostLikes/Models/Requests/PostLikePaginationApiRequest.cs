namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record PostLikePaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
