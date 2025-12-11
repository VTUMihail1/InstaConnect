using InstaConnect.Identity.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailConfirmationTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IEmailConfirmationTokenIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<EmailConfirmationToken>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapCreator(c => new EmailConfirmationToken(
                c.Id,
                c.ExpiresAtUtc,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
