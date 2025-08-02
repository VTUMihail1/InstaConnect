namespace InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

public record PostCommentPaginationApiRequest(
    [FromQuery(Name = "page")] int Page = 1,
    [FromQuery(Name = "pageSize")] int PageSize = 20);
