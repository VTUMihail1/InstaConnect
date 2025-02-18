namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetUserByIdRequest([FromRoute] string Id);
