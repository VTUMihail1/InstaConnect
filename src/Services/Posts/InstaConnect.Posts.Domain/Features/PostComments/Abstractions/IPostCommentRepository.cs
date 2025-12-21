using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentRepository
{
    Task<PostCommentCollection> GetAllAsync(
        PostCommentFilterQuery filter,
        CommonSortingQuery<PostCommentSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<PostCommentIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        CommonIncludeQuery<PostCommentIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<PostComment?> GetByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken);

    Task AddAsync(PostComment entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<PostComment> entities, CancellationToken cancellationToken);

    Task UpdateAsync(PostComment entity, CancellationToken cancellationToken);

    Task DeleteAsync(PostComment entity, CancellationToken cancellationToken);
}
