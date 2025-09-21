namespace InstaConnect.Users.Application.Features.Users.Models;

public record UserQueryResponse(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImage);
