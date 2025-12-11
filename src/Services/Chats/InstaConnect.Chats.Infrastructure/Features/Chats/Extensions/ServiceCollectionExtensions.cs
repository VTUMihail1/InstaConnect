using InstaConnect.Chats.Infrastructure.Extensions;

using MongoDB.Bson.Serialization;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddChatServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IChatByParticipantSortProperty>(ChatInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IChatIncludeProperty>(ChatInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<Chat>(cm =>
        {
            cm.MapIdMember(c => c.Id);

            cm.MapMember(c => c.Id);
            cm.MapMember(c => c.CreatedAtUtc);

            cm.MapMember(c => c.ParticipantOne);
            cm.MapMember(c => c.ParticipantTwo);
            cm.MapMember(c => c.Messages);

            cm.MapCreator(c => new Chat(
                c.Id,
                c.CreatedAtUtc));

            cm.SetIgnoreExtraElements(true);
        });

        return serviceCollection;
    }
}
