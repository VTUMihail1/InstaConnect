using InstaConnect.Chats.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddChatMessageServices()
        {
            serviceCollection.AddImplementationsOf<IChatMessagesSortTermer>(ChatsInfrastructureReference.Assembly);
            serviceCollection.AddImplementationsOf<IChatMessageIncluder>(ChatsInfrastructureReference.Assembly);

            BsonClassMap.TryRegisterClassMap<ChatMessage>(cm =>
            {
                cm.MapIdMember(c => c.Id);

                cm.MapMember(c => c.Id);
                cm.MapMember(c => c.SenderId);
                cm.MapMember(c => c.Content);
                cm.MapMember(c => c.CreatedAtUtc);
                cm.MapMember(c => c.UpdatedAtUtc);

                cm.MapMemberWithoutSerialization(c => c.Chat);
                cm.MapMemberWithoutSerialization(c => c.Sender);

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
}
