using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;
internal interface IPostCommentService
{
    public void Update(PostComment postComment, string content);

    public void AddLike(PostComment postComment, string userId);

    public void RemoveLike(PostComment postComment, string postCommentLikeId);
}
