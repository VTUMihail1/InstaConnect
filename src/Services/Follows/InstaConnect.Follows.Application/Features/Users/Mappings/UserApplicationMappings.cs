using InstaConnect.Follows.Application.Features.Users.Commands.Add;
using InstaConnect.Follows.Application.Features.Users.Commands.Delete;
using InstaConnect.Follows.Application.Features.Users.Commands.Update;

using Mapster;

namespace InstaConnect.Follows.Application.Features.Users.Mappings;

internal class UserApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddUserCommandRequest, AddUserCommand>()
            .ConstructUsing(src => new(
                new(src.Id),
                src.FirstName,
                src.LastName,
                new(src.Name),
                new(src.Email),
                new(src.ProfileImageUrl),
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<User, AddUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdCommandResponse>(config)));

        config.NewConfig<UpdateUserCommandRequest, UpdateUserCommand>()
            .ConstructUsing(src => new(
                new(src.Id),
                src.FirstName,
                src.LastName,
                new(src.Name),
                new(src.Email),
                new(src.ProfileImageUrl),
                src.UpdatedAtUtc));

        config.NewConfig<User, UpdateUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdCommandResponse>(config)));

        config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(
                                       new(src.Id)));

        config.NewConfig<UserId, UserIdCommandResponse>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, UserQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.Name.Value,
                src.ProfileImage.IsNull() ? null : src.ProfileImage!.Url));
    }
}
