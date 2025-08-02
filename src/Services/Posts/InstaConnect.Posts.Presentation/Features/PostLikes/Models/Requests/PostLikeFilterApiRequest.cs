namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

public record PostLikeFilterApiRequest(
    [FromRoute] string Id,
    [FromQuery(Name = "userId")] string UserId = "",
    [FromQuery(Name = "userName")] string UserName = "");
