using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;

public class PostCommentLike : IEntity
{
    private PostCommentLike()
    {
        Id = string.Empty;
        CommentId = string.Empty;
        CommentLikeId = string.Empty;
        UserId = string.Empty;
    }

    public PostCommentLike(
        string id,
        string commentId,
        string commentLikeId,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        CommentLikeId = commentLikeId;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostCommentLike(
        string id,
        string commentId,
        string commentLikeId,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        CommentLikeId = commentLikeId;
        UserId = user.Id;
        User = user;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string CommentId { get; private set; }

    public string CommentLikeId { get; private set; }

    public string UserId { get; }

    public User? User { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }
}
