using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeRepository
{
    Task<PostCommentLikeCollection> GetAllAsync(
        GetAllPostCommentLikesQuery query,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        string id, 
        string commentId, 
        string commentLikeId, 
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAndUserIdAsync(
        string id,
        string commentId,
        string userId,
        CancellationToken cancellationToken);

    void Add(PostCommentLike postCommentLike);

    void Update(PostCommentLike postCommentLike);

    void Delete(PostCommentLike postCommentLike);
}
