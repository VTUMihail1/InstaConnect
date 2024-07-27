using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Read.Data.Models.Entities;

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
