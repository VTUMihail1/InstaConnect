namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeQueryRepository
{
    Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
        PostCommentLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
        PostCommentLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostCommentLikesSortingQuery sorting,
        PostCommentLikesPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        PostCommentLikesFilterQuery filter,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        PostCommentLikesFilterQuery filter,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForUserAsync(
        PostCommentLikesForUserFilterQuery filter,
        CancellationToken cancellationToken);

    Task<PostCommentLikeResponse?> GetByIdAsync(
        PostCommentLikeId id,
        CurrentUserQuery currentUser,
        PostCommentLikeInclude? include,
        CancellationToken cancellationToken);

    Task<PostCommentLikeResponse?> GetByIdAsync(
        PostCommentLikeId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        PostCommentLikeId id,
        CancellationToken cancellationToken);
}
