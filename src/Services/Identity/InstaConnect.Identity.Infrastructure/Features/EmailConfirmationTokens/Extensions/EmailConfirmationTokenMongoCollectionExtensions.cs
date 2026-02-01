using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

public static class EmailConfirmationTokenMongoCollectionExtensions
{
    public static async Task UpdateAsync(
        this IMongoCollection<EmailConfirmationToken> collection,
        IClientSessionHandle? session,
        EmailConfirmationToken entity,
        CancellationToken cancellationToken)
    {
        await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);

    }

    public static async Task DeleteRangeAsync(
        this IMongoCollection<EmailConfirmationToken> collection,
        IClientSessionHandle? session,
        IEnumerable<EmailConfirmationToken> entities,
        CancellationToken cancellationToken)
    {
        await collection.DeleteRangeAsync(session, entities.Select(p => p.Id).GetFilter(), cancellationToken);
    }
}
