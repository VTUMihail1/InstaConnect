using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

public static class ForgotPasswordTokenMongoCollectionExtensions
{
    extension(IMongoCollection<ForgotPasswordToken> collection)
    {
        public async Task UpdateAsync(
            IClientSessionHandle? session,
            ForgotPasswordToken entity,
            CancellationToken cancellationToken)
        {
            await collection.UpdateAsync(session, entity.Id.GetFilter(), entity, cancellationToken);
        }

        public async Task DeleteRangeAsync(
            IClientSessionHandle? session,
            IEnumerable<ForgotPasswordToken> entities,
            CancellationToken cancellationToken)
        {
            await collection.DeleteRangeAsync(session, entities.Select(p => p.Id).GetFilter(), cancellationToken);
        }
    }
}
