using System.Xml.Serialization;

using InstaConnect.Common.Events.Models;

using Mapster;

namespace InstaConnect.Identity.Domain.Features.Users.Mappings;

internal class UserDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdEventPayload>(),
                src.Name.Adapt<NameEventPayload>(),
                src.Email.Adapt<EmailEventPayload>(),
                src.FirstName,
                src.LastName,
                src.ProfileImage.Adapt<ImageEventPayload>()));

        config.NewConfig<User, UserUpdatedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdEventPayload>(),
                src.Name.Adapt<NameEventPayload>(),
                src.Email.Adapt<EmailEventPayload>(),
                src.FirstName,
                src.LastName,
                src.ProfileImage.Adapt<ImageEventPayload>()));

        config.NewConfig<User, UserDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdEventPayload>()));

        config.NewConfig<UserId, UserIdEventPayload>()
            .ConstructUsing(src => new(src.Id));
    }
}
