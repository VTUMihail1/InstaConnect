namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

public class PostLike : IEntity
{
    private PostLike()
    {
        Id = string.Empty;
        UserId = string.Empty;
    }

    public PostLike(
        string id,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostLike(
        string id,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        User = user;
        UserId = user.Id;
    }

    public string Id { get; }

    public string UserId { get; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }

    public void AddUser(User user)
    {
        User = user;
    }
}
