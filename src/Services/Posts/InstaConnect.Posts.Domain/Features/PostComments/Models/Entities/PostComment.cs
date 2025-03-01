using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

public class PostComment : IBaseEntity, IAuditableInfo
{
    private PostComment()
    {
        Id = string.Empty;
        UserId = string.Empty;
        PostId = string.Empty;
        Content = string.Empty;
        PostCommentLikes = [];
    }

    public PostComment(
        string id,
        string userId,
        string postId,
        string content,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        UserId = userId;
        PostId = postId;
        Content = content;
        PostCommentLikes = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostComment(
        string id,
        User user,
        Post post,
        string content,
        ICollection<PostCommentLike> postCommentLikes,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        User = user;
        Post = post;
        UserId = user.Id;
        PostId = post.Id;
        Content = content;
        PostCommentLikes = postCommentLikes;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;

    }

    public string Id { get; }

    public string UserId { get; }

    public string PostId { get; }

    public string Content { get; private set; }

    public User? User { get; }

    public Post? Post { get; }

    public ICollection<PostCommentLike> PostCommentLikes { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(string content, DateTimeOffset updatedAt)
    {
        Content = content;
        UpdatedAt = updatedAt;
    }
}
