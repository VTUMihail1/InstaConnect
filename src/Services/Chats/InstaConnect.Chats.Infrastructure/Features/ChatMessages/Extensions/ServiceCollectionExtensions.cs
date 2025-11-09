using InstaConnect.Chats.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddChatMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IChatMessageSortProperty>(ChatInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IChatMessageIncludeProperty>(ChatInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<ChatMessage>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.ParticipantOneId, c.ParticipantTwoId, c.MessageId })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.Sender);
        });

        return serviceCollection;
    }
}
