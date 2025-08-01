using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

public class PostComment : IEntity
{
    private PostComment()
    {
        Id = string.Empty;
        CommentId = string.Empty;
        Content = string.Empty;
        UserId = string.Empty;
        Likes = [];
    }

    public PostComment(
        string id,
        string commentId,
        string content,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        Content = content;
        UserId = userId;
        Likes = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostComment(
        string id,
        string commentId,
        string content,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        Content = content;
        UserId = user.Id;
        User = user;
        Likes = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostComment(
        string id,
        string commentId,
        string content,
        User user,
        ICollection<PostCommentLike> likes,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        Content = content;
        UserId = user.Id;
        User = user;
        Likes = likes;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string CommentId { get; }

    public string Content { get; private set; }

    public string UserId { get; }

    public User? User { get; }

    public ICollection<PostCommentLike> Likes { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string content, DateTimeOffset updatedAt)
    {
        Content = content;
        UpdatedAt = updatedAt;
    }
}
