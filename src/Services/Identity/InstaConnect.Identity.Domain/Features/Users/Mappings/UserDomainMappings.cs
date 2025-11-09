using Mapster;

namespace InstaConnect.Identity.Domain.Features.Users.Mappings;

internal class UserDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserAddedEventRequest>()
            .ConstructUsing(u => new(
                u.Id,
                u.Name,
                u.Email,
                u.FirstName,
                u.LastName,
                u.ProfileImage));

        config.NewConfig<User, UserUpdatedEventRequest>()
            .ConstructUsing(u => new(
                u.Id,
                u.Name,
                u.Email,
                u.FirstName,
                u.LastName,
                u.ProfileImage));

        config.NewConfig<User, UserDeletedEventRequest>()
            .ConstructUsing(u => new(u.Id));
    }
}
