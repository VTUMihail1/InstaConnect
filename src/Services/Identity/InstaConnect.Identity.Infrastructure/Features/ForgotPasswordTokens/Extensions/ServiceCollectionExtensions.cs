using InstaConnect.Identity.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddForgotPasswordTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IForgotPasswordTokenIncluder>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<ForgotPasswordToken>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMemberWithoutSerialization(c => c.User);

            cm.MapCreator(c => new ForgotPasswordToken(
                c.Id,
                c.ExpiresAtUtc,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
