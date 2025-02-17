namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record GetAllPostCommentLikesRequest(
    [FromQuery(Name = "userId")] string UserId = "",
    [FromQuery(Name = "userName")] string UserName = "",
    [FromQuery(Name = "postCommentId")] string PostCommentId = "",
    [FromQuery(Name = "sortOrder")] SortOrder SortOrder = SortOrder.ASC,
    [FromQuery(Name = "sortPropertyName")] string SortPropertyName = "CreatedAt",
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20
);
