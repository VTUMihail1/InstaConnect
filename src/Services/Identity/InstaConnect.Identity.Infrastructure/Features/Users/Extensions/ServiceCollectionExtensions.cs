using InstaConnect.Identity.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserSortProperty>(IdentityInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<User>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => c.Id);

            cm.UnmapMember(c => c.Claims);
            cm.UnmapMember(c => c.RefreshTokens);
            cm.UnmapMember(c => c.ForgotPasswordTokens);
            cm.UnmapMember(c => c.EmailConfirmationTokens);
        });

        return serviceCollection;
    }
}
