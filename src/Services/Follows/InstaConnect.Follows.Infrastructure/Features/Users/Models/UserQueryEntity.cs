namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record UserQueryEntity(
        string Id,
        string Name,
        string Email,
        string FirstName,
        string LastName,
        string ProfileImage,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
