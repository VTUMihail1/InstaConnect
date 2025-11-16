using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

public class PostComment : IEntity<PostCommentId>
{
    private readonly IList<PostCommentLike> _likes;

    private PostComment()
    {
        Id = new(new(string.Empty), string.Empty);
        Content = string.Empty;
        UserId = new(string.Empty);
        _likes = [];
    }

    public PostComment(
        PostCommentId id,
        string content,
        UserId userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Content = content;
        UserId = userId;
        _likes = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostComment(
        PostCommentId id,
        string content,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Content = content;
        UserId = user.Id;
        User = user;
        _likes = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostComment(
        PostCommentId id,
        string content,
        User user,
        IList<PostCommentLike> likes,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Content = content;
        UserId = user.Id;
        User = user;
        _likes = likes;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostCommentId Id { get; }

    public string Content { get; private set; }

    public UserId UserId { get; }

    public User? User { get; private set; }

    public IReadOnlyCollection<PostCommentLike> Likes => _likes.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string content, DateTimeOffset updatedAt)
    {
        Content = content;
        UpdatedAt = updatedAt;
    }

    public bool IsOwnedByUser(UserId userId)
    {
        var isOwnedByUser = UserId.EqualsOrdinalIgnoreCase(userId);

        return isOwnedByUser;
    }

    public bool IsNotOwnedByUser(UserId userId)
    {
        var isNotOwnedByUser = !IsOwnedByUser(userId);

        return isNotOwnedByUser;
    }

    public void AddUser(User user)
    {
        User = user;
    }
}
