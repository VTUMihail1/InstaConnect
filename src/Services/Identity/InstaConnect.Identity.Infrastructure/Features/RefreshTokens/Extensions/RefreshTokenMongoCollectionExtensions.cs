using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

public static class RefreshTokenMongoCollectionExtensions
{
	extension(IMongoCollection<RefreshToken> collection)
	{
		public async Task UpdateAsync(
			IClientSessionHandle? session,
			RefreshToken entity,
			CancellationToken cancellationToken)
		{
			await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
		}

		public async Task DeleteAsync(
			IClientSessionHandle? session,
			RefreshToken entity,
			CancellationToken cancellationToken)
		{
			await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
		}
	}
}
