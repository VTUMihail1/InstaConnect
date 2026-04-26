namespace InstaConnect.Posts.Domain.Features.Users.Models.Requests;

public record AddUserCommand(
    UserId Id,
    string FirstName,
    string LastName,
    Name Name,
    Email Email,
    Image? ProfileImage,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc);
