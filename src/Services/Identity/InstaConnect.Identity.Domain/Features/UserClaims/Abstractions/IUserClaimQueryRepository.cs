namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimQueryRepository
{
    Task<ICollection<UserClaimResponse>> GetAllAsync(
        UserClaimsFilterQuery filter,
        CurrentUserQuery current,
        UserClaimsSortingQuery sorting,
        UserClaimsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        UserClaimsFilterQuery filter,
        CancellationToken cancellationToken);

    Task<UserClaimResponse?> GetByIdAsync(
        UserClaimId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        UserClaimId id,
        CancellationToken cancellationToken);
}
