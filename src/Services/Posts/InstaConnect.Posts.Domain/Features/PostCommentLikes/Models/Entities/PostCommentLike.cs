using InstaConnect.Common.Extensions;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;

public class PostCommentLike : IEntity
{
    private PostCommentLike()
    {
        Id = string.Empty;
        CommentId = string.Empty;
        UserId = string.Empty;
    }

    public PostCommentLike(
        string id,
        string commentId,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostCommentLike(
        string id,
        string commentId,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        UserId = user.Id;
        User = user;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string CommentId { get; }

    public string UserId { get; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }

    public void AddUser(User user)
    {
        User = user;
    }
}
