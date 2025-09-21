namespace InstaConnect.Users.Infrastructure.Features.Users.Models;

public record UserQueryEntity(
        string Id,
        string Name,
        string Email,
        string FirstName,
        string LastName,
        string PasswordHash,
        bool IsEmailConfirmed,
        string? ProfileImage,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
