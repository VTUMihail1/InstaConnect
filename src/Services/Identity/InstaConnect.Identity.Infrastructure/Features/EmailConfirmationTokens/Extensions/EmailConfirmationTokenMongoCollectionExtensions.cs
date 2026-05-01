using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

public static class EmailConfirmationTokenMongoCollectionExtensions
{
	extension(IMongoCollection<EmailConfirmationToken> collection)
	{
		public async Task UpdateAsync(
			IClientSessionHandle? session,
			EmailConfirmationToken entity,
			CancellationToken cancellationToken)
		{
			await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
		}

		public async Task DeleteAsync(
			IClientSessionHandle? session,
			EmailConfirmationToken entity,
			CancellationToken cancellationToken)
		{
			await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
		}

		public async Task DeleteRangeAsync(
			IClientSessionHandle? session,
			IEnumerable<EmailConfirmationToken> entities,
			CancellationToken cancellationToken)
		{
			await collection.DeleteRangeAsync(session, entities.Select(p => p.Id).GetFilter(), cancellationToken);
		}
	}
}
