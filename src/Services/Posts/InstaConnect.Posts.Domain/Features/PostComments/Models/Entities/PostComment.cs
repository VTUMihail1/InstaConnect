using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

public class PostComment : BaseEntity
{
    public PostComment(
        string userId,
        string postId,
        string content)
    {
        UserId = userId;
        PostId = postId;
        Content = content;
    }

    public PostComment(
        User user,
        Post post,
        string content)
    {
        User = user;
        Post = post;
        UserId = user.Id;
        PostId = post.Id;
        Content = content;
    }

    public string UserId { get; }

    public string PostId { get; }

    public string Content { get; set; }

    public User? User { get; set; }

    public Post? Post { get; set; }

    public ICollection<PostCommentLike> PostCommentLikes { get; set; } = [];
}
