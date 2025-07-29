namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

public record PostLikeQueryEntity(
        string Id,
        string LikeId,
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
