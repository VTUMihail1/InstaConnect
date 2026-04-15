using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

public static class UserClaimMongoCollectionExtensions
{
    extension(IMongoCollection<UserClaim> collection)
    {
        public async Task DeleteAsync(IClientSessionHandle? session, UserClaim entity, CancellationToken cancellationToken)
        {
            await collection.DeleteAsync(session, entity.Id.GetFilter(), cancellationToken);
        }
    }
}
