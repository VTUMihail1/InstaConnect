using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Models.Entitites;

public class PostLike : BaseEntity
{
    public PostLike(
        string postId,
        string userId)
    {
        PostId = postId;
        UserId = userId;
    }

    public string PostId { get; }

    public string UserId { get; }

    public Post? Post { get; set; }

    public User? User { get; set; }
}
