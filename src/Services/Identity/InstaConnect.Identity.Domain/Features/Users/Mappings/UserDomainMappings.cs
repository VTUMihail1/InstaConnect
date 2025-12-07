using InstaConnect.Common.Domain.Extensions;

using Mapster;

namespace InstaConnect.Identity.Domain.Features.Users.Mappings;

internal class UserDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.Name.Value,
                src.Email.Value,
                src.FirstName,
                src.LastName,
                src.ProfileImage.IsNull() ? null : src.ProfileImage!.Url,
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<User, UserUpdatedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.Name.Value,
                src.Email.Value,
                src.FirstName,
                src.LastName,
                src.ProfileImage.IsNull() ? null : src.ProfileImage!.Url,
                src.UpdatedAtUtc));

        config.NewConfig<User, UserDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Id));
    }
}
