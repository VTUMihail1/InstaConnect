using InstaConnect.Common.Application.Models;
using InstaConnect.Common.Domain.Models.ValueObjects;
using InstaConnect.Follows.Application.Features.Users.Commands.Add;
using InstaConnect.Follows.Application.Features.Users.Commands.Delete;
using InstaConnect.Follows.Application.Features.Users.Commands.Update;
using InstaConnect.Follows.Application.Features.Users.Models;
using InstaConnect.Follows.Domain.Features.Users.Models.ValueObjects;

using Mapster;

namespace InstaConnect.Follows.Application.Features.Users.Mappings;

public class UserApplicationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AddUserCommandRequest, AddUserCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserId>(),
                src.FirstName,
                src.LastName,
                src.Name.Adapt<Name>(),
                src.Email.Adapt<Email>(),
                src.ProfileImage.Adapt<Image>()));

        config.NewConfig<User, AddUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<UpdateUserCommandRequest, UpdateUserCommand>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserId>(),
                src.FirstName,
                src.LastName,
                src.Name.Adapt<Name>(),
                src.Email.Adapt<Email>(),
                src.ProfileImage.Adapt<Image>()));

        config.NewConfig<User, UpdateUserCommandResponse>()
            .ConstructUsing(src => new(src.Id.Adapt<UserIdPayload>()));

        config.NewConfig<DeleteUserCommandRequest, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id.Adapt<UserId>()));

        config.NewConfig<UserIdPayload, UserId>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<UserId, UserIdPayload>()
            .ConstructUsing(src => new(src.Id));

        config.NewConfig<User, UserQueryResponse>()
            .ConstructUsing(src => new(
                src.Id.Adapt<UserIdPayload>(),
                src.Name.Adapt<NamePayload>(),
                src.ProfileImage.Adapt<ImagePayload>()));
    }
}
