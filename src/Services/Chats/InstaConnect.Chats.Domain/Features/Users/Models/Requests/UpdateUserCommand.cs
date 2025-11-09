namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record UpdateUserCommand(
    string Id,
    string Email,
    string FirstName,
    string LastName,
    string Name,
    string? ProfileImage);
