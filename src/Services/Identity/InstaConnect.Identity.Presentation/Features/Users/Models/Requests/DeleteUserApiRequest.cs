namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record DeleteUserApiRequest(
    [FromRoute] string Id
);
