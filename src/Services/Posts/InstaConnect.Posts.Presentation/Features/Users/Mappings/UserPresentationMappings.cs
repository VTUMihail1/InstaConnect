using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.Users.Mappings;

internal class UserPresentationMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserCreatedEvent, AddUserCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.FirstName,
                src.LastName,
                src.Name,
                src.Email,
                src.ProfileImage));

        config.NewConfig<UserUpdatedEvent, UpdateUserCommand>()
            .ConstructUsing(src => new(
                src.Id,
                src.FirstName,
                src.LastName,
                src.Name,
                src.ProfileImage));

        config.NewConfig<UserDeletedEvent, DeleteUserCommand>()
            .ConstructUsing(src => new(src.Id));
    }
}
