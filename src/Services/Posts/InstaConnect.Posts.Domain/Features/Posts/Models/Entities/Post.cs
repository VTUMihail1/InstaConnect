using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

public class Post : IEntity
{
    private Post()
    {
        Id = string.Empty;
        Title = string.Empty;
        Content = string.Empty;
        UserId = string.Empty;
        Likes = [];
        Comments = [];
    }

    public Post(
        string id,
        string title,
        string content,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = userId;
        Likes = [];
        Comments = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Post(
        string id,
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
        Likes = [];
        Comments = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Post(
        string id,
        string title,
        string content,
        User user,
        ICollection<PostLike> likes,
        ICollection<PostComment> comments,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        UserId = user.Id;
        User = user;
        Likes = likes;
        Comments = comments;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public string Id { get; }

    public string Title { get; private set; }

    public string Content { get; private set; }

    public string UserId { get; }

    public User? User { get; }

    public ICollection<PostLike> Likes { get; }

    public ICollection<PostComment> Comments { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string title, string content, DateTimeOffset updatedAt)
    {
        Title = title;
        Content = content;
        UpdatedAt = updatedAt;
    }
}
