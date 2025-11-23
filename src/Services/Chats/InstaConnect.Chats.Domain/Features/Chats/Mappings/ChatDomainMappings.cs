using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Chats.Domain.Features.Chats.Mappings;

internal class ChatDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Chat, ChatAddedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatIdEventPayload>()));

        config.NewConfig<Chat, ChatDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<ChatIdEventPayload>()));

        config.NewConfig<ChatId, ChatIdEventPayload>()
            .ConstructUsing(src => new(
                src.ParticipantOneId.Adapt<UserIdEventPayload>(),
                src.ParticipantTwoId.Adapt<UserIdEventPayload>()));
    }
}
