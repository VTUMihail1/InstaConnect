using InstaConnect.Identity.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddRefreshTokenServices()
        {
            serviceCollection.AddImplementationsOf<IRefreshTokenIncluder>(IdentityInfrastructureReference.Assembly);

            BsonClassMap.TryRegisterClassMap<RefreshToken>(cm =>
            {
                cm.MapIdMember(c => c.Id);

                cm.MapMember(c => c.Id);
                cm.MapMember(c => c.CreatedAtUtc);

                cm.MapMemberWithoutSerialization(c => c.User);

                cm.MapCreator(c => new RefreshToken(
                    c.Id,
                    c.ExpiresAtUtc,
                    c.CreatedAtUtc));

                cm.SetIgnoreExtraElements(true);
            });

            return serviceCollection;
        }
    }
}
