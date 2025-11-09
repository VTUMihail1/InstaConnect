namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentRepository
{
    Task<PostCommentCollection> GetAllAsync(
        PostCommentFilterQuery filter,
        PostCommentSortingQuery sorting,
        PostCommentPaginationQuery pagination,
        PostCommentIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostComment?> GetByIdAsync(
        string id,
        string commentId,
        PostCommentIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostComment?> GetByIdAsync(
        string id,
        string commentId,
        CancellationToken cancellationToken);

    Task AddAsync(PostComment entity, CancellationToken cancellationToken);

    Task UpdateAsync(PostComment entity, CancellationToken cancellationToken);

    Task DeleteAsync(PostComment entity, CancellationToken cancellationToken);
}
