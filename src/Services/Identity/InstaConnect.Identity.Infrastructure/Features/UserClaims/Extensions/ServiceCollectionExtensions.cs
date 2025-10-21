using InstaConnect.Common.Extensions;
using InstaConnect.UserClaims.Infrastructure.Extensions;
using InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using InstaConnect.Posts.Domain.Features.UserClaims.Models.Entities;
using InstaConnect.Users.Infrastructure.Extensions;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserClaimServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserClaimIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<UserClaim>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.Id, c.Value })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });

        return serviceCollection;
    }
}
