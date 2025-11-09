using Mapster;

namespace InstaConnect.Follows.Domain.Features.Follows.Mappings;

internal class FollowDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Follow, FollowAddedEventRequest>()
            .ConstructUsing(p => new(
                p.FollowerId,
                p.FollowingId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<Follow, FollowDeletedEventRequest>()
            .ConstructUsing(p => new(p.FollowerId, p.FollowingId));
    }
}
