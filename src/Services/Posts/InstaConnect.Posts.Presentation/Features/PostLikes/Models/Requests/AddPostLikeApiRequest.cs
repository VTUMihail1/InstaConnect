namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record AddPostLikeApiRequest(
    [FromRoute] string Id,
    [UserIdFromClaim] string UserId
);
