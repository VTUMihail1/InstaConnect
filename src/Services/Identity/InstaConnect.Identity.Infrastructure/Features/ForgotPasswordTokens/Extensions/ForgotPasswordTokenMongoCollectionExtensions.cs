using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenMongoCollectionExtensions
{
    public static async Task UpdateAsync(
        this IMongoCollection<ForgotPasswordToken> collection,
        IClientSessionHandle? session,
        ForgotPasswordToken entity,
        CancellationToken cancellationToken)
    {
        await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);

    }

    public static async Task DeleteRangeAsync(
        this IMongoCollection<ForgotPasswordToken> collection,
        IClientSessionHandle? session,
        IEnumerable<ForgotPasswordToken> entities,
        CancellationToken cancellationToken)
    {
        await collection.DeleteRangeAsync(session, entities.Select(p => p.Id).GetFilter(), cancellationToken);
    }
}
