using InstaConnect.Common.Extensions;
using InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Users.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.EmailConfirmationTokens.Infrastructure.Features.EmailConfirmationTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddEmailConfirmationTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IEmailConfirmationTokenIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<EmailConfirmationToken>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.Id, c.Value })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });

        return serviceCollection;
    }
}
