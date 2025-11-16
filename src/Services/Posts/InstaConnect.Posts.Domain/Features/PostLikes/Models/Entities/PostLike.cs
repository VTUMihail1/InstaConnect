namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

public class PostLike : IEntity<PostLikeId>
{
    private PostLike()
    {
        Id = new(new(string.Empty), new(string.Empty));
    }

    public PostLike(
        PostLikeId id,
        DateTimeOffset createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public PostLike(
        PostLikeId id,
        User user,
        DateTimeOffset createdAt)
    {
        Id = id;
        User = user;
        CreatedAt = createdAt;
    }

    public PostLikeId Id { get; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAt { get; }

    public void AddUser(User user)
    {
        User = user;
    }
}
