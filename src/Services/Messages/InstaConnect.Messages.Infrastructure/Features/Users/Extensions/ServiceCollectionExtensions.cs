using InstaConnect.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Extensions;
using InstaConnect.Users.Infrastructure.Features.Users.Abstractions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

namespace InstaConnect.Users.Infrastructure.Features.Users.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddUserServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IUserIncludeProperty>(ChatInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<User>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => c.Id)
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.Chats);
            cm.UnmapMember(c => c.ChatMessages);
        });

        return serviceCollection;
    }
}
