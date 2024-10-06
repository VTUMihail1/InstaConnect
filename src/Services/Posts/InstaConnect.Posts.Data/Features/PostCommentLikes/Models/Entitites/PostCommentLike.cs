using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;

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
