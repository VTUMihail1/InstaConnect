namespace InstaConnect.PostLikes.Presentation.Features.PostLikes.Models.Requests;

public record GetPostLikeByIdApiRequest(
    [FromRoute] string Id,
    [FromRoute] string LikeId
);
