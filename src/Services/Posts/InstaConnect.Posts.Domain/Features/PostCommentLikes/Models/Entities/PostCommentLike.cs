using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;

public class PostCommentLike : IBaseEntity, IAuditableInfo
{
    private PostCommentLike()
    {
        Id = string.Empty;
        UserId = string.Empty;
        PostCommentId = string.Empty;
    }

    public PostCommentLike(
        string id,
        string postCommentId,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        PostCommentId = postCommentId;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostCommentLike(
        string id,
        PostComment postComment,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        PostComment = postComment;
        User = user;
        PostCommentId = postComment.Id;
        UserId = user.Id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string PostCommentId { get; }

    public string UserId { get; }

    public PostComment? PostComment { get; }

    public User? User { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
