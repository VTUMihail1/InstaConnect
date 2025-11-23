using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Follows.Domain.Features.Follows.Mappings;

internal class FollowDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Follow, FollowAddedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<FollowIdEventPayload>()));

        config.NewConfig<Follow, FollowDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<FollowIdEventPayload>()));

        config.NewConfig<FollowId, FollowIdEventPayload>()
            .ConstructUsing(src => new(
                src.FollowerId.Adapt<UserIdEventPayload>(),
                src.FollowingId.Adapt<UserIdEventPayload>()));
    }
}
