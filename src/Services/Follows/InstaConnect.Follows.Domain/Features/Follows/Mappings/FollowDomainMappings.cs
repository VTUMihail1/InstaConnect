using Mapster;

namespace InstaConnect.Follows.Domain.Features.Follows.Mappings;

internal class FollowDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Follow, FollowAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.FollowerId.Id,
                src.Id.FollowingId.Id,
                src.CreatedAtUtc));

        config.NewConfig<Follow, FollowDeletedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.FollowerId.Id,
                src.Id.FollowingId.Id));
    }
}
