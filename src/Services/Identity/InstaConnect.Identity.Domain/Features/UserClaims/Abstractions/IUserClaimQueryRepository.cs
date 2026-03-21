namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimQueryRepository
{
    Task<ICollection<UserClaimResponse>> GetAllAsync(
        UserClaimsFilterQuery filter,
        CurrentUserQuery current,
        UserClaimsSortingQuery sorting,
        UserClaimsPaginationQuery pagination,
        UserClaimInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<UserClaimResponse>> GetAllAsync(
        UserClaimsFilterQuery filter,
        CurrentUserQuery current,
        UserClaimsSortingQuery sorting,
        UserClaimsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        UserClaimsFilterQuery filter,
        UserClaimInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        UserClaimsFilterQuery filter,
        CancellationToken cancellationToken);

    Task<UserClaimResponse?> GetByIdAsync(
        UserClaimId id,
        CurrentUserQuery current,
        UserClaimInclude? include,
        CancellationToken cancellationToken);

    Task<UserClaimResponse?> GetByIdAsync(
        UserClaimId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        UserClaimId id,
        CancellationToken cancellationToken);
}
