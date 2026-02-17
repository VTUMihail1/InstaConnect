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

    public PostLikeId Id { get; }

    public Post? Post { get; private set; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; }

    public PostLike AddUser(User? user)
    {
        User = user;

        return this;
    }

    public PostLike AddPost(Post? post)
    {
        Post = post;

        return this;
    }
}
