using InstaConnect.Common.Extensions;
using InstaConnect.Chats.Infrastructure.Extensions;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;
using InstaConnect.Shared.Infrastructure.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddChatServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddImplementationsOf<IChatByParticipantSortProperty>(ChatInfrastructureReference.Assembly);
        serviceCollection.AddImplementationsOf<IChatIncludeProperty>(ChatInfrastructureReference.Assembly);

        BsonClassMap.RegisterClassMap<Chat>(cm =>
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
