namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

public record PostLikeFilterApiRequest(
    [FromRoute] string Id,
    [FromQuery(Name = "userName")] string UserName = "");
