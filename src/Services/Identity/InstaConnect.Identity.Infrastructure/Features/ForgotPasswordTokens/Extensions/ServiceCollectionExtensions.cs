using InstaConnect.Common.Extensions;
using InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Users.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddForgotPasswordTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IForgotPasswordTokenIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<ForgotPasswordToken>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.Id, c.Value })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });

        return serviceCollection;
    }
}
