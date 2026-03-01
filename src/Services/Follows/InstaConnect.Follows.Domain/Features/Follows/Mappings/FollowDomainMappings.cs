using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Follows.Domain.Features.Follows.Mappings;

internal class FollowDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Follow, FollowAddedEventRequest>()
            .ConstructUsing(src => new(src.Adapt<FollowEventRequest>(config)));

        config.NewConfig<Follow, FollowDeletedEventRequest>()
            .ConstructUsing(src => new(src.Adapt<FollowEventRequest>(config)));

        config.NewConfig<Follow, FollowEventRequest>()
            .ConstructUsing(src => new(
                src.Id.FollowerId.Id,
                src.Id.FollowingId.Id,
                src.Follower.Adapt<UserEventRequest>(config),
                src.Following.Adapt<UserEventRequest>(config),
                src.CreatedAtUtc));
    }
}
