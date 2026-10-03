namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Helpers.Repositories;

internal class RefreshTokenCommandRepository : IRefreshTokenCommandRepository
{
	private readonly IRefreshTokenCollection _collection;

	public RefreshTokenCommandRepository(IRefreshTokenCollection collection)
	{
		_collection = collection;
	}

	public async Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		RefreshTokenInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<RefreshToken?> GetByIdAsync(
		RefreshTokenId id,
		CancellationToken cancellationToken)
	{
		return await GetByIdAsync(id, null, cancellationToken);
	}

	public async Task AddAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<RefreshToken> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
