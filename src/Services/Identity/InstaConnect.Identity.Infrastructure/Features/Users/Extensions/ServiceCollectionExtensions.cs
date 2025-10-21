using InstaConnect.Common.Extensions;
using InstaConnect.Users.Infrastructure.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Users.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserSortProperty>(IdentityInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(IdentityInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<User>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => c.Id)
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.Claims);
            cm.UnmapMember(c => c.RefreshTokens);
            cm.UnmapMember(c => c.ForgotPasswordTokens);
            cm.UnmapMember(c => c.EmailConfirmationTokens);
        });

        return serviceCollection;
    }
}
