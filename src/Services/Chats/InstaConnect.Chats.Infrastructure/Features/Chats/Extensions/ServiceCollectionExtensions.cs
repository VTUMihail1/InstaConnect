using InstaConnect.Chats.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection serviceCollection)
    {
        internal IServiceCollection AddChatServices()
        {
            serviceCollection.AddImplementationsOf<IChatsSortTermer>(ChatInfrastructureReference.Assembly);
            serviceCollection.AddImplementationsOf<IChatIncluder>(ChatInfrastructureReference.Assembly);

            BsonClassMap.TryRegisterClassMap<Chat>(cm =>
            {
                cm.MapIdMember(c => c.Id);

                cm.MapMember(c => c.Id);
                cm.MapMember(c => c.CreatedAtUtc);

                cm.MapMemberWithoutSerialization(c => c.ParticipantOne);
                cm.MapMemberWithoutSerialization(c => c.ParticipantTwo);
                cm.MapMemberWithoutSerialization(c => c.ChatMessages);

                cm.MapCreator(c => new Chat(
                    c.Id,
                    c.CreatedAtUtc));

                cm.SetIgnoreExtraElements(true);
            });

            return serviceCollection;
        }
    }
}
