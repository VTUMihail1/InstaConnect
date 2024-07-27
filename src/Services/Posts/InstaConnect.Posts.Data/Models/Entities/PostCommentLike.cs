using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Read.Data.Models.Entities;

public class PostCommentLike : BaseEntity
{
    public PostCommentLike(
        string postCommentId, 
        string userId)
    {
        PostCommentId = postCommentId;
        UserId = userId;
    }

    public string PostCommentId { get; }

    public string UserId { get; }

    public PostComment? PostComment { get; set; }

    public User? User { get; set; }
}
