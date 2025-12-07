using InstaConnect.Chats.Application.Features.Users.Commands.Add;
using InstaConnect.Chats.Application.Features.Users.Commands.Delete;
using InstaConnect.Chats.Application.Features.Users.Commands.Update;

using Mapster;

namespace InstaConnect.Chats.Presentation.Features.Users.Mappings;

internal class UserPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserAddedEventRequest, AddUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.FirstName,
                src.LastName,
                src.Name,
                src.Email,
                src.ProfileImageUrl,
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<UserUpdatedEventRequest, UpdateUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.FirstName,
                src.LastName,
                src.Name,
                src.Email,
                src.ProfileImageUrl,
                src.UpdatedAtUtc));

        config.NewConfig<UserDeletedEventRequest, DeleteUserCommandRequest>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserQueryResponse, UserApiResponse>()
            .ConstructUsing(src => new(
                src.Id,
                src.Name,
                src.ProfileImageUrl));
    }
}
