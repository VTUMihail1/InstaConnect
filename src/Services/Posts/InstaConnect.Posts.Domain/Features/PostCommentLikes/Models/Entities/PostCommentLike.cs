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
        DateTimeOffset createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public PostCommentLike(
        PostCommentLikeId id,
        User user,
        DateTimeOffset createdAt)
    {
        Id = id;
        User = user;
        CreatedAt = createdAt;
    }

    public PostCommentLikeId Id { get; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAt { get; }

    public void AddUser(User user)
    {
        User = user;
    }
}
