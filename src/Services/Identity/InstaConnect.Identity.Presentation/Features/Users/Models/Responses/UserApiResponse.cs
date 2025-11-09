namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserApiResponse(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImage);
