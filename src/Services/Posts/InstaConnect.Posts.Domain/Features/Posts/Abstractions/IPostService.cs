using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostService
{
    public void Update(Post post, string title, string content);

    public void GetAllComments(Post post, PostCommentCollectionReadQuery query);

    public void GetCommentById(Post post, string commentId);

    public void AddComment(Post post, string content, string userId);

    public void RemoveComment(Post post, string commentId);

    public void GetAllLikes(Post post, PostLikeCollectionReadQuery query);

    public void GetLikeById(Post post, string likeId);

    public void AddLike(Post post, string userId);

    public void RemoveLike(Post post, string likeId);

    public void GetAllCommentLikes(Post post, string commentId, PostLikeCollectionReadQuery query);

    public void GetCommentLikeById(Post post, string commentId, string commentLikeId);

    public void AddCommentLike(Post post, string commentId, string userId);

    public void RemoveCommentLike(Post post, string commentLikeId);

}
