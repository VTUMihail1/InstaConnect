namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record PostCommentLikePaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
