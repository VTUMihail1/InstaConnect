using AutoMapper;

using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Update;
using InstaConnect.Users.Application.Features.Users.Models;
using InstaConnect.Users.Application.Features.Users.Queries.GetAll;
using InstaConnect.Users.Domain.Features.Users.Models.Events;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;
using InstaConnect.Users.Infrastructure.Features.Users.Models;

using Mapster;

namespace InstaConnect.Users.Infrastructure.Features.Users.Mappings;

internal class UserInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserQueryEntity, User>()
              .ConstructUsing(u => new(
                            u.Id,
                            u.FirstName,
                            u.LastName,
                            u.Email,
                            u.Name,
                            u.PasswordHash,
                            u.IsEmailConfirmed,
                            u.ProfileImage,
                            u.CreatedAt,
                            u.UpdatedAt));
    }
}
