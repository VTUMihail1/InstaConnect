namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentCommandRepository
{
    Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        PostCommentInclude? include,
        CancellationToken cancellationToken);

    Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostComment entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken);

    Task UpdateAsync(PostComment entity, CancellationToken cancellationToken);

    Task DeleteAsync(PostComment entity, CancellationToken cancellationToken);
}
