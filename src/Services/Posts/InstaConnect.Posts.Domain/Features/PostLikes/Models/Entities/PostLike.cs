namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

public class PostLike : IEntityWithId<PostLikeId>
{
    private PostLike()
    {
        Id = new(new(string.Empty), new(string.Empty));
    }

    public PostLike(
        PostLikeId id,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        CreatedAtUtc = createdAtUtc;
    }

    public PostLike(
        PostLikeId id,
        User user,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        User = user;
        CreatedAtUtc = createdAtUtc;
    }

    public PostLikeId Id { get; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; }

    public void AddUser(User user)
    {
        User = user;
    }
}
