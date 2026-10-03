namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Helpers.Repositories;

internal class PostLikeCommandRepository : IPostLikeCommandRepository
{
	private readonly IPostLikeCollection _collection;

	public PostLikeCommandRepository(IPostLikeCollection collection)
	{
		_collection = collection;
	}

	public async Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		PostLikeInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<PostLike?> GetByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		return await GetByIdAsync(id, null, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostLike> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(PostLike entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
