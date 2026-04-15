namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record DeletePostApiRequest(
    [FromRoute] string Id,
    [UserIdFromClaim] string UserId
);
