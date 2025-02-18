using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

public class PostLike : BaseEntity
{
    public PostLike(
        string postId,
        string userId)
    {
        PostId = postId;
        UserId = userId;
    }

    public PostLike(
        Post post,
        User user)
    {
        Post = post;
        User = user;
        PostId = post.Id;
        UserId = user.Id;
    }

    public string PostId { get; }

    public string UserId { get; }

    public Post? Post { get; set; }

    public User? User { get; set; }
}
