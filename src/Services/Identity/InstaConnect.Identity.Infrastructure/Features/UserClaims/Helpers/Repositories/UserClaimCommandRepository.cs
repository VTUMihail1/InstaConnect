namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Helpers.Repositories;

internal class UserClaimCommandRepository : IUserClaimCommandRepository
{
	private readonly IUserClaimCollection _collection;

	public UserClaimCommandRepository(IUserClaimCollection collection)
	{
		_collection = collection;
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
		UserClaimInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<UserClaim?> GetByIdAsync(
		UserClaimId id,
		CancellationToken cancellationToken)
	{
		return await GetByIdAsync(id, null, cancellationToken);
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

	public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(UserClaim entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
