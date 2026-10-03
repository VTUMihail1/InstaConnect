using InstaConnect.Common.Domain.Features.ValueObjects.Models;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Helpers.Repositories;

internal class UserCommandRepository : IUserCommandRepository
{
	private readonly IUserCollection _collection;

	public UserCommandRepository(IUserCollection collection)
	{
		_collection = collection;
	}

	public async Task<User?> GetByIdAsync(
		UserId id,
		UserInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<User?> GetByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		return await GetByIdAsync(id, null, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		UserId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}

	public async Task<User?> GetByNameAsync(
		Name name,
		UserInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(name)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<User?> GetByNameAsync(
		Name name,
		CancellationToken cancellationToken)
	{
		return await GetByNameAsync(name, null, cancellationToken);
	}

	public async Task<bool> IsNameUniqueAsync(
		Name name,
		CancellationToken cancellationToken)
	{
		return !await _collection
			.AggregateFluent()
			.Match(name)
			.AnyAsync(cancellationToken);
	}

	public async Task<User?> GetByEmailAsync(
		Email email,
		UserInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(email)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<User?> GetByEmailAsync(
		Email email,
		CancellationToken cancellationToken)
	{
		return await GetByEmailAsync(email, null, cancellationToken);
	}

	public async Task<bool> IsEmailUniqueAsync(
		Email email,
		CancellationToken cancellationToken)
	{
		return !await _collection
			.AggregateFluent()
			.Match(email)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(User entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task UpdateAsync(User entity, CancellationToken cancellationToken)
	{
		await _collection.UpdateAsync(entity, cancellationToken);
	}

	public async Task DeleteAsync(User entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
