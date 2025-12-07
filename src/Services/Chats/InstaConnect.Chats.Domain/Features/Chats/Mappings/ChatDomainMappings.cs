using Mapster;

namespace InstaConnect.Chats.Domain.Features.Chats.Mappings;

internal class ChatDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Chat, ChatAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.ParticipantOneId.Id,
                src.Id.ParticipantTwoId.Id,
                src.CreatedAtUtc));

        config.NewConfig<Chat, ChatDeletedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.ParticipantOneId.Id,
                src.Id.ParticipantTwoId.Id));
    }
}
