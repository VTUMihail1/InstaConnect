namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentQueryRepository
{
    Task<ICollection<PostCommentResponse>> GetAllAsync(
        PostCommentsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        PostCommentInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<PostCommentResponse>> GetAllAsync(
        PostCommentsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsForUserSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        PostCommentInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentsForUserSortingQuery sorting,
        PostCommentsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        PostCommentsFilterQuery filter,
        PostCommentInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        PostCommentsFilterQuery filter,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForUserAsync(
        PostCommentsForUserFilterQuery filter,
        PostCommentInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForUserAsync(
        PostCommentsForUserFilterQuery filter,
        CancellationToken cancellationToken);

    Task<PostCommentResponse?> GetByIdAsync(
        PostCommentId id,
        CurrentUserQuery currentUser,
        PostCommentInclude? include,
        CancellationToken cancellationToken);

    Task<PostCommentResponse?> GetByIdAsync(
        PostCommentId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        PostCommentId id,
        CancellationToken cancellationToken);
}
