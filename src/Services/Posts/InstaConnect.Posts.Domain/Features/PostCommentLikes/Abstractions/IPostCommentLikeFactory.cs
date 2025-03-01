using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeFactory
{
    public PostCommentLike Get(string postCommentId, string userId);
}
