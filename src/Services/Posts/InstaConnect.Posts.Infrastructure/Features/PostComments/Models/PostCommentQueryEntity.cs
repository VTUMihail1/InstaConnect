namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;

public record PostCommentQueryEntity(
        string Id,
        string CommentId,
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
