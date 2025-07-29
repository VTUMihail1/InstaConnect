namespace InstaConnect.Posts.Application.Features.Posts.Commands.Add;

public record UpdateUserCommand(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImage);
