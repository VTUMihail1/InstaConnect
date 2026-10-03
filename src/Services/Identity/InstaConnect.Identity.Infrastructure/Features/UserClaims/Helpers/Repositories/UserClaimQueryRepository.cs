namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class UserClaimQueryRepository : IUserClaimQueryRepository
{
	private readonly IUserClaimCollection _collection;

	public UserClaimQueryRepository(IUserClaimCollection collection)
	{
		_collection = collection;
	}

	public async Task<ICollection<UserClaimResponse>> GetAllAsync(
		UserClaimsFilterQuery filter,
		CurrentUserQuery current,
		UserClaimsSortingQuery sorting,
		UserClaimsPaginationQuery pagination,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.ProjectToResponseWithoutUser(current)
			.ApplySorting(sorting)
			.ApplyPagination(pagination)
			.ToListAsync(cancellationToken);
	}

	public async Task<long> GetTotalCountAsync(
		UserClaimsFilterQuery filter,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(filter)
			.GetCountAsync(cancellationToken);
	}

	public async Task<UserClaimResponse?> GetByIdAsync(
		UserClaimId id,
		CurrentUserQuery current,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.ProjectToFullResponse(current)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		UserClaimId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}
}
