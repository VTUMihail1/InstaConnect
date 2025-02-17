namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record DeleteUserRequest(
    [FromRoute] string Id
);
