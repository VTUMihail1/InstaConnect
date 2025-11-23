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

        BsonClassMap.TryRegisterClassMap<ChatMessage>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => c.Id);

            cm.UnmapMember(c => c.Sender);
        });

        return serviceCollection;
    }
}
