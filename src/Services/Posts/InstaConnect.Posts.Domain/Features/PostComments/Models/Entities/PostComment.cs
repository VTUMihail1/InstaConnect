namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

public class PostComment : IEntity<PostCommentId>
{
    private PostComment()
    {
        Id = new(new(string.Empty), string.Empty);
        Content = string.Empty;
        UserId = new(string.Empty);
        Likes = [];
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
        Likes = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public PostCommentId Id { get; }

    public string Content { get; private set; }

    public UserId UserId { get; }

    public User? User { get; private set; }

    public ICollection<PostCommentLike> Likes { get; }

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

    public void AddLike(PostCommentLike like)
    {
        Likes.Add(like);
    }
}
