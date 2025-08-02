namespace InstaConnect.PostComments.Presentation.Features.PostComments.Models.Requests;

public record PostCommentFilterApiRequest(
    [FromRoute] string Id,
    [FromQuery(Name = "userId")] string UserId = "",
    [FromQuery(Name = "userName")] string UserName = "");
