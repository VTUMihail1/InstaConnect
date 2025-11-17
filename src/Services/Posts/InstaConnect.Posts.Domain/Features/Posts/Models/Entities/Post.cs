using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

public class Post : IEntity<PostId>
{
    private Post()
    {
        Id = new(string.Empty);
        Title = string.Empty;
        Content = string.Empty;
        UserId = new(string.Empty);
        Likes = [];
        Comments = [];
    }

    public Post(
        PostId id,
        string title,
        string content,
        UserId userId,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = userId;
        Likes = [];
        Comments = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public Post(
        PostId id,
        string title,
        string content,
        User user,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = user.Id;
        User = user;
        Likes = [];
        Comments = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public Post(
        PostId id,
        string title,
        string content,
        User user,
        IList<PostLike> likes,
        IList<PostComment> comments,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = user.Id;
        User = user;
        Likes = likes;
        Comments = comments;
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public PostId Id { get; }

    public string Title { get; private set; }

    public string Content { get; private set; }

    public UserId UserId { get; }

    public User? User { get; private set; }

    public ICollection<PostLike> Likes { get; }

    public ICollection<PostComment> Comments { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public void Update(string title, string content, DateTimeOffset updatedAtUtc)
    {
        Title = title;
        Content = content;
        UpdatedAtUtc = updatedAtUtc;
    }

    public void AddUser(User user)
    {
        User = user;
    }

    public void AddComment(PostComment comment)
    {
        Comments.Add(comment);
    }

    public void AddLike(PostLike like)
    {
        Likes.Add(like);
    }
}
