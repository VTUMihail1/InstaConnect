using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Abstractions;
using InstaConnect.Users.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddRefreshTokenServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IRefreshTokenIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<RefreshToken>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.Id, c.Value })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });

        return serviceCollection;
    }
}
