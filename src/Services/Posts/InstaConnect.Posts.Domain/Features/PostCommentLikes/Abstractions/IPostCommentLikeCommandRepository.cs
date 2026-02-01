namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeCommandRepository
{
    Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken);

    Task<PostCommentLike?> GetByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken);

    Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken);
}
