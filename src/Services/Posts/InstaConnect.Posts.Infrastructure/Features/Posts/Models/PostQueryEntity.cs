namespace InstaConnect.Posts.Infrastructure.Features.Posts.Models;

public record PostQueryEntity(
        string Id,
        string Title,
        string Content,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        string UserId,
        string UserName,
        string UserEmail,
        string UserFirstName,
        string UserLastName,
        string UserProfileImage,
        DateTimeOffset UserCreatedAt,
        DateTimeOffset UserUpdatedAt);
