using InstaConnect.Identity.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserClaimServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserClaimIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<UserClaim>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapCreator(c => new UserClaim(
                new(
                    new(c.Id.Id.Id),
                    c.Id.Claim),
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
