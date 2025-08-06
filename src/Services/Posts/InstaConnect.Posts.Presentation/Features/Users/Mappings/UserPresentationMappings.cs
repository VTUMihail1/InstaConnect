using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Delete;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Delete;

using Mapster;

namespace InstaConnect.Posts.Presentation.Features.Users.Mappings;

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
                src.ProfileImage));

        config.NewConfig<UserUpdatedEventRequest, UpdateUserCommandRequest>()
            .ConstructUsing(src => new(
                src.Id,
                src.FirstName,
                src.LastName,
                src.Name,
                src.Email,
                src.ProfileImage));

        config.NewConfig<UserDeletedEventRequest, DeleteUserCommandRequest>()
            .ConstructUsing(src => new(src.Id));
    }
}
