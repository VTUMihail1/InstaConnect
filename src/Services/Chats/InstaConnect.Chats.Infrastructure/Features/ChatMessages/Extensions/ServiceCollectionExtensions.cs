using InstaConnect.Chats.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddChatMessageServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IChatMessageSortProperty>(ChatInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IChatMessageIncludeProperty>(ChatInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<ChatMessage>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.SenderId);

            cm.MapMember(c => c.Content);
            cm.MapMember(c => c.CreatedAtUtc);
            cm.MapMember(c => c.UpdatedAtUtc);

            cm.MapMember(c => c.Sender);

            cm.MapCreator(c => new ChatMessage(
                c.Id,
                c.SenderId,
                c.Content,
                c.CreatedAtUtc,
                c.UpdatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
