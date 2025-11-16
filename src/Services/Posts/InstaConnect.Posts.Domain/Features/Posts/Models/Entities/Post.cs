using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

public class Post : IEntity<PostId>
{
    private readonly IList<PostLike> _likes;
    private readonly IList<PostComment> _comments;

    private Post()
    {
        Id = new(string.Empty);
        Title = string.Empty;
        Content = string.Empty;
        UserId = new(string.Empty);
        _likes = [];
        _comments = [];
    }

    public Post(
        PostId id,
        string title,
        string content,
        UserId userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = userId;
        _likes = [];
        _comments = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Post(
        PostId id,
        string title,
        string content,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = user.Id;
        User = user;
        _likes = [];
        _comments = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Post(
        PostId id,
        string title,
        string content,
        User user,
        IList<PostLike> likes,
        IList<PostComment> comments,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = user.Id;
        User = user;
        _likes = likes;
        _comments = comments;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostId Id { get; }

    public string Title { get; private set; }

    public string Content { get; private set; }

    public UserId UserId { get; }

    public User? User { get; private set; }

    public IReadOnlyCollection<PostLike> Likes => _likes.AsReadOnly();

    public IReadOnlyCollection<PostComment> Comments => _comments.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string title, string content, DateTimeOffset updatedAt)
    {
        Title = title;
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

    public void AddComment(PostComment comment)
    {
        _comments.Add(comment);
    }

    public void AddLike(PostLike like)
    {
        _likes.Add(like);
    }
}
