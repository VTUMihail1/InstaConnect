namespace InstaConnect.Users.Application.Features.Users.Models;

public record UserDetailsApiResponse(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImage);
