using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeFactory
{
    public PostCommentLike Create(string postCommentId, string userId);
}
