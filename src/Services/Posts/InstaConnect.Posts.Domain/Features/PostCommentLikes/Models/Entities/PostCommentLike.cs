namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;

public class PostCommentLike : IEntityWithId<PostCommentLikeId>
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

    public PostCommentLikeId Id { get; }

    public PostComment? PostComment { get; private set; }

    public User? User { get; private set; }

    public DateTimeOffset CreatedAtUtc { get; }

    public PostCommentLike AddUser(User? user)
    {
        User = user;

        return this;
    }

    public PostCommentLike AddPostComment(PostComment? postComment)
    {
        PostComment = postComment;

        return this;
    }
}
