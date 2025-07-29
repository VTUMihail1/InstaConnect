using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Domain.Features.Posts.Models.Events;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

using Mapster;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Mappings;

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
                            u.ProfileImage,
                            u.CreatedAt,
                            u.UpdatedAt));
    }
}
