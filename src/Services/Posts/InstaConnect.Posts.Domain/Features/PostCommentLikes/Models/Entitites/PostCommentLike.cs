using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;

public class PostCommentLike : BaseEntity
{
    public PostCommentLike(
        string postCommentId,
        string userId)
    {
        PostCommentId = postCommentId;
        UserId = userId;
    }

    public PostCommentLike(
        PostComment postComment,
        User user)
    {
        PostComment = postComment;
        User = user;
        PostCommentId = postComment.Id;
        UserId = user.Id;
    }

    public string PostCommentId { get; }

    public string UserId { get; }

    public PostComment? PostComment { get; set; }

    public User? User { get; set; }
}
