namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Repositories;

internal class EmailConfirmationTokenCommandRepository : IEmailConfirmationTokenCommandRepository
{
	private readonly IEmailConfirmationTokenCollection _collection;

	public EmailConfirmationTokenCommandRepository(IEmailConfirmationTokenCollection collection)
	{
		_collection = collection;
	}

	public async Task<EmailConfirmationToken?> GetByIdAsync(
		EmailConfirmationTokenId id,
		EmailConfirmationTokenInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<EmailConfirmationToken?> GetByIdAsync(
		EmailConfirmationTokenId id,
		CancellationToken cancellationToken)
	{
		return await GetByIdAsync(id, null, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		EmailConfirmationTokenId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(EmailConfirmationToken entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}

	public async Task DeleteRangeAsync(IEnumerable<EmailConfirmationToken> entities, CancellationToken cancellationToken)
	{
		await _collection.DeleteRangeAsync(entities, cancellationToken);
	}
}
