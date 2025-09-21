namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;

public record PostCommentLikeQueryEntity(
        string Id,
        string CommentId,
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
