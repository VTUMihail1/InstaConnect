namespace InstaConnect.Posts.Infrastructure.Features.PostCommentLikes.Helpers.Repositories;

internal class PostCommentLikeCommandRepository : IPostCommentLikeCommandRepository
{
	private readonly IPostCommentLikeCollection _collection;

	public PostCommentLikeCommandRepository(IPostCommentLikeCollection collection)
	{
		_collection = collection;
	}

	public async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		PostCommentLikeInclude? include,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.ApplyIncludes(include)
			.Match(id)
			.FirstOrDefaultAsync(cancellationToken);
	}

	public async Task<PostCommentLike?> GetByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		return await GetByIdAsync(id, null, cancellationToken);
	}

	public async Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken)
	{
		return await _collection
			.AggregateFluent()
			.Match(id)
			.AnyAsync(cancellationToken);
	}

	public async Task AddAsync(PostCommentLike entity, CancellationToken cancellationToken)
	{
		await _collection.AddAsync(entity, cancellationToken);
	}

	public async Task AddRangeAsync(IEnumerable<PostCommentLike> entities, CancellationToken cancellationToken)
	{
		await _collection.AddRangeAsync(entities, cancellationToken);
	}

	public async Task DeleteAsync(PostCommentLike entity, CancellationToken cancellationToken)
	{
		await _collection.DeleteAsync(entity, cancellationToken);
	}
}
