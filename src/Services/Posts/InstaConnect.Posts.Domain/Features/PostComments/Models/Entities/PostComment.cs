using InstaConnect.Common.Extensions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;

public class PostComment : IEntity
{
    private readonly IList<PostCommentLike> _likes;

    private PostComment()
    {
        Id = string.Empty;
        CommentId = string.Empty;
        Content = string.Empty;
        UserId = string.Empty;
        _likes = [];
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
        _likes = [];
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
        _likes = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostComment(
        string id,
        string commentId,
        string content,
        User user,
        IList<PostCommentLike> likes,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        CommentId = commentId;
        Content = content;
        UserId = user.Id;
        User = user;
        _likes = likes;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string CommentId { get; }

    public string Content { get; private set; }

    public string UserId { get; }

    public User? User { get; private set; }

    public IReadOnlyCollection<PostCommentLike> Likes => _likes.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string content, DateTimeOffset updatedAt)
    {
        Content = content;
        UpdatedAt = updatedAt;
    }

    public bool IsOwnedByUser(string userId)
    {
        var isOwnedByUser = UserId.EqualsOrdinalIgnoreCase(userId);

        return isOwnedByUser;
    }

    public bool IsNotOwnedByUser(string userId)
    {
        var isNotOwnedByUser = !IsOwnedByUser(userId);

        return isNotOwnedByUser;
    }

    public void AddUser(User user)
    {
        User = user;
    }
}
