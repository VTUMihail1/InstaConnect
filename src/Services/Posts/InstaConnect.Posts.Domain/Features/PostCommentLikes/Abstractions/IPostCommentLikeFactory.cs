using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeFactory
{
    public PostCommentLike Create(string id, string commentId, string userId);
}
