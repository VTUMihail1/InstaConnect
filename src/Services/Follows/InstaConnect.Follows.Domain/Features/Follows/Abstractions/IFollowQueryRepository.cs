namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowQueryRepository
{
    Task<ICollection<FollowResponse>> GetAllAsync(
        FollowsFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsSortingQuery sorting,
        FollowsPaginationQuery pagination,
        FollowInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<FollowResponse>> GetAllAsync(
        FollowsFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsSortingQuery sorting,
        FollowsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<ICollection<FollowResponse>> GetAllForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsForFollowingSortingQuery sorting,
        FollowsPaginationQuery pagination,
        FollowInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<FollowResponse>> GetAllForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        CurrentUserQuery currentUser,
        FollowsForFollowingSortingQuery sorting,
        FollowsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        FollowsFilterQuery filter,
        FollowInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        FollowsFilterQuery filter,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        FollowInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForFollowingAsync(
        FollowsForFollowingFilterQuery filter,
        CancellationToken cancellationToken);

    Task<FollowResponse?> GetByIdAsync(
        FollowId id,
        CurrentUserQuery currentUser,
        FollowInclude? include,
        CancellationToken cancellationToken);

    Task<FollowResponse?> GetByIdAsync(
        FollowId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        FollowId id,
        CancellationToken cancellationToken);
}
