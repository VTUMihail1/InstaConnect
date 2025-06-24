namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record PostFilterApiRequest(
    [FromQuery(Name = "userId")] string UserId = "",
    [FromQuery(Name = "userName")] string UserName = "",
    [FromQuery(Name = "title")] string Title = "");
