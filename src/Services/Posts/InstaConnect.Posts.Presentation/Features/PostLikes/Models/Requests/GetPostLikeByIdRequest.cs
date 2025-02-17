namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record GetPostLikeByIdRequest(
    [FromRoute] string Id
);
