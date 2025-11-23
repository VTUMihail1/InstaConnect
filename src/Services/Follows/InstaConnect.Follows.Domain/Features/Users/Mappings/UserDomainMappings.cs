using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Follows.Domain.Features.Users.Mappings;

internal class UserDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserId, UserIdEventPayload>()
            .ConstructUsing(src => new(src.Id));
    }
}
