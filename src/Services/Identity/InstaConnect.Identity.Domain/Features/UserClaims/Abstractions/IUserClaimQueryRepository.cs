namespace InstaConnect.Identity.Domain.Features.UserClaims.Abstractions;

public interface IUserClaimQueryRepository
{
	public Task<ICollection<UserClaimResponse>> GetAllAsync(
		UserClaimsFilterQuery filter,
		UserClaimsSortingQuery sorting,
		UserClaimsPaginationQuery pagination,
		CurrentUserQuery current,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		UserClaimsFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<UserClaimResponse?> GetByIdAsync(
		UserClaimId id,
		CurrentUserQuery current,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		UserClaimId id,
		CancellationToken cancellationToken);
}
