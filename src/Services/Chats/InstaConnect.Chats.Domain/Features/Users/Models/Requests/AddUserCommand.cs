namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record AddUserCommand(
    string Id,
    string FirstName,
    string LastName,
    string Name,
    string Email,
    string? ProfileImage);
