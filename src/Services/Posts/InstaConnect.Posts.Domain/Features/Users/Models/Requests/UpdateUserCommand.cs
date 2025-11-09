namespace InstaConnect.Posts.Domain.Features.Users.Models.Requests;

public record UpdateUserCommand(
    string Id,
    string Email,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImage);
