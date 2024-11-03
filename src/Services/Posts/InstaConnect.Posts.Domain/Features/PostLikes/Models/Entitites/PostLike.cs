using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;

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
