using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

using Mapster;

namespace InstaConnect.Chats.Domain.Features.Chats.Mappings;

internal class ChatDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Chat, ChatAddedEventRequest>()
            .ConstructUsing(p => new(
                p.ParticipantOneId,
                p.ParticipantTwoId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<Chat, ChatDeletedEventRequest>()
            .ConstructUsing(p => new(p.ParticipantOneId, p.ParticipantTwoId));
    }
}
