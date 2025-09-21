namespace InstaConnect.Users.Application.Features.Users.Models;

public record UserApiResponse(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImage);
