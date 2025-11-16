using InstaConnect.Chats.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddChatServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IChatByParticipantSortProperty>(ChatInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IChatIncludeProperty>(ChatInfrastructureReference.Assembly);

        BsonClassMap.TryRegisterClassMap<Chat>(cm =>
        {
            cm.AutoMap();

            cm.MapIdMember(c => new { c.ParticipantOneId, c.ParticipantTwoId })
              .SetSerializer(new StringSerializer(BsonType.ObjectId));

            cm.UnmapMember(c => c.ParticipantOne);
            cm.UnmapMember(c => c.ParticipantTwo);
            cm.UnmapMember(c => c.Messages);
        });

        return serviceCollection;
    }
}
