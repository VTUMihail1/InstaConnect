using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;

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

    public string UserId { get; }

    public string PostId { get; }

    public string Content { get; set; }

    public User? User { get; set; }

    public Post? Post { get; set; }

    public ICollection<PostCommentLike> PostCommentLikes { get; set; } = [];
}
