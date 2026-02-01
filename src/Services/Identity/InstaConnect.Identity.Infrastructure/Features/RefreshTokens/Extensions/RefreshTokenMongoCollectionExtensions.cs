using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

public static class RefreshTokenMongoCollectionExtensions
{
    public static async Task UpdateAsync(
        this IMongoCollection<RefreshToken> collection,
        IClientSessionHandle? session,
        RefreshToken entity,
        CancellationToken cancellationToken)
    {
        await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);

    }

    public static async Task DeleteAsync(
        this IMongoCollection<RefreshToken> collection,
        IClientSessionHandle? session,
        RefreshToken entity,
        CancellationToken cancellationToken)
    {
        await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
    }
}
