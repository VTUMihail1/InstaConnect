using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeRepository
{
    Task<PostCommentLikeCollection> GetAllAsync(
        PostCommentLikeFilterQuery filter,
        PostCommentLikeSortingQuery sorting,
        PostCommentLikePaginationQuery pagination,
        PostCommentLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        string id,
        string commentId,
        string userId,
        PostCommentLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        string id,
        string commentId,
        string userId,
        CancellationToken cancellationToken);

    Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken);

    Task UpdateAsync(PostCommentLike entity, CancellationToken cancellationToken);

    Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken);
}
