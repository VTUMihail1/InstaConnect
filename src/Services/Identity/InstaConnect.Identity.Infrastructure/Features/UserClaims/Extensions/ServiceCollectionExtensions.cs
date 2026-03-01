using InstaConnect.Identity.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserClaimServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserClaimIncluder>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<UserClaim>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMemberWithoutSerialization(c => c.User);

            cm.MapCreator(c => new UserClaim(
                c.Id,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
