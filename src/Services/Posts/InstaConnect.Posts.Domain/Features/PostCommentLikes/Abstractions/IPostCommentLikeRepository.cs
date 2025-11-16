namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeRepository
{
    Task<PostCommentLikeCollection> GetAllAsync(
        PostCommentLikeFilterQuery filter,
        PostCommentLikeSortingQuery sorting,
        PostCommentLikePaginationQuery pagination,
        PostCommentLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        PostCommentLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken);

    Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken);
}
