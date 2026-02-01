namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeQueryRepository
{
    Task<ICollection<PostLikeResponse>> GetAllAsync(
        PostLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        PostLikeInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<PostLikeResponse>> GetAllAsync(
        PostLikesFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        PostLikesFilterQuery filter,
        PostLikeInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        PostLikesFilterQuery filter,
        CancellationToken cancellationToken);

    Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
        PostLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        PostLikeInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
        PostLikesForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostLikesSortingQuery sorting,
        PostLikesPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForUserAsync(
        PostLikesForUserFilterQuery filter,
        PostLikeInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForUserAsync(
        PostLikesForUserFilterQuery filter,
        CancellationToken cancellationToken);

    Task<PostLikeResponse?> GetByIdAsync(
        PostLikeId id,
        CurrentUserQuery currentUser,
        PostLikeInclude? include,
        CancellationToken cancellationToken);

    Task<PostLikeResponse?> GetByIdAsync(
        PostLikeId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        PostLikeId id,
        CancellationToken cancellationToken);
}
