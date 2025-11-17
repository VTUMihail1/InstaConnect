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
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        Content = content;
        UserId = userId;
        _likes = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public PostComment(
        PostCommentId id,
        string content,
        User user,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        Content = content;
        UserId = user.Id;
        User = user;
        _likes = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public PostComment(
        PostCommentId id,
        string content,
        User user,
        IList<PostCommentLike> likes,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        Content = content;
        UserId = user.Id;
        User = user;
        _likes = likes;
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public PostCommentId Id { get; }

    public string Content { get; private set; }

    public UserId UserId { get; }

    public User? User { get; private set; }

    public IReadOnlyCollection<PostCommentLike> Likes => _likes.AsReadOnly();

    public DateTimeOffset CreatedAtUtc { get; }

    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public void Update(string content, DateTimeOffset updatedAtUtc)
    {
        Content = content;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void AddUser(User user)
    {
        User = user;
    }
}
