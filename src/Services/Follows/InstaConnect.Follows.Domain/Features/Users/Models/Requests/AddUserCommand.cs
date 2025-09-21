namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record AddUserCommand(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImage);
