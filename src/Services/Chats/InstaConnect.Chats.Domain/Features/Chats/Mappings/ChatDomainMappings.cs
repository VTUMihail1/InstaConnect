using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Chats.Domain.Features.Chats.Mappings;

internal class ChatDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Chat, ChatAddedEventRequest>()
            .ConstructUsing(src => new(src.Adapt<ChatEventRequest>(config)!));

        config.NewConfig<Chat, ChatDeletedEventRequest>()
            .ConstructUsing(src => new(src.Adapt<ChatEventRequest>(config)!));

        config.NewConfig<Chat, ChatEventRequest>()
            .ConstructUsing(src => new(
                src.Id.ParticipantOneId.Id,
                src.Id.ParticipantTwoId.Id,
                src.ParticipantOne.Adapt<UserEventRequest>(config)!,
                src.ParticipantTwo.Adapt<UserEventRequest>(config)!,
                src.CreatedAtUtc));
    }
}
