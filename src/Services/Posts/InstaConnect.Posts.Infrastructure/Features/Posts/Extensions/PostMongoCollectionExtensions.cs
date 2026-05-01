using MongoDB.Driver;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Extensions;

internal static class PostMongoCollectionExtensions
{
	extension(IMongoCollection<Post> collection)
	{
		public async Task UpdateAsync(
			IClientSessionHandle? session,
			Post entity,
			CancellationToken cancellationToken)
		{
			await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
		}

		public async Task DeleteAsync(
			IClientSessionHandle? session,
			Post entity,
			CancellationToken cancellationToken)
		{
			await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
		}
	}
}
