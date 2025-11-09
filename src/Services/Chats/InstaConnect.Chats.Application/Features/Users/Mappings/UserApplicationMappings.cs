using InstaConnect.Chats.Application.Features.Users.Commands.Add;
using InstaConnect.Chats.Application.Features.Users.Commands.Delete;
using InstaConnect.Chats.Application.Features.Users.Commands.Update;

using Mapster;

namespace InstaConnect.Chats.Application.Features.Users.Mappings;

public class UserApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddUserCommandRequest, AddUserCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.FirstName,
                src.LastName,
                src.Name,
                src.Email,
                src.ProfileImage));

        config.NewConfig<User, AddUserCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<UpdateUserCommandRequest, UpdateUserCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.Email,
                src.FirstName,
                src.LastName,
                src.Name,
                src.ProfileImage));

        config.NewConfig<User, UpdateUserCommandResponse>()
            .ConstructUsing(src => new(src.Id, src.CreatedAt, src.UpdatedAt));

        config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id));
    }
}
