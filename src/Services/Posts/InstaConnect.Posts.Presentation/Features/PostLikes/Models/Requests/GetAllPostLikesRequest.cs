namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetAllPostLikesRequest(
    [FromRoute] string PostId,
    [FromQuery(Name = "userId")] string UserId = "",
    [FromQuery(Name = "userName")] string UserName = "",
    [FromQuery(Name = "sortOrder")] SortOrder SortOrder = SortOrder.ASC,
    [FromQuery(Name = "sortPropertyName")] string SortPropertyName = "CreatedAt",
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20
);
