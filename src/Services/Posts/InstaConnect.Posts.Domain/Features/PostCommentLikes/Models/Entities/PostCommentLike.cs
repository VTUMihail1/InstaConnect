namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;

public class PostCommentLike : IEntity<PostCommentLikeId>
{
    private PostCommentLike()
    {
        Id = new(
                 new(
                     new(string.Empty),
                     string.Empty),
                 new(string.Empty));
    }

    public PostCommentLike(
        PostCommentLikeId id,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        CreatedAtUtc = createdAtUtc;
    }

    public PostCommentLike(
        PostCommentLikeId id,
        User user,
        DateTimeOffset createdAtUtc)
    {
        Id = id;
        User = user;
        CreatedAtUtc = createdAtUtc;
    }

    public PostCommentLikeId Id { get; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; }

    public void AddUser(User user)
    {
        User = user;
    }
}
