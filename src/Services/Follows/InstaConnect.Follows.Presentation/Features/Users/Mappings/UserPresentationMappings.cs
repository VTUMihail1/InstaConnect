using InstaConnect.Follows.Application.Features.Users.Commands.Add;
using InstaConnect.Follows.Application.Features.Users.Commands.Delete;
using InstaConnect.Follows.Application.Features.Users.Commands.Update;

using Mapster;

namespace InstaConnect.Follows.Presentation.Features.Users.Mappings;

internal class UserPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserAddedEventRequest, AddUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.FirstName,
                src.LastName,
                src.Name.Adapt<NamePayload>(),
                src.Email.Adapt<EmailPayload>(),
                src.ProfileImage.Adapt<ImagePayload>()));

        config.NewConfig<UserUpdatedEventRequest, UpdateUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.FirstName,
                src.LastName,
                src.Name.Adapt<NamePayload>(),
                src.Email.Adapt<EmailPayload>(),
                src.ProfileImage.Adapt<ImagePayload>()));

        config.NewConfig<UserDeletedEventRequest, DeleteUserCommandRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<UserIdPayload, UserIdApiPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserIdApiPayload, UserIdPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserIdPayload, UserIdEventPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserIdEventPayload, UserIdPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserQueryResponse, UserApiResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdApiPayload>(),
                src.Name.Adapt<NameApiPayload>(),
                src.ProfileImage.Adapt<ImageApiPayload>()));
    }
}
