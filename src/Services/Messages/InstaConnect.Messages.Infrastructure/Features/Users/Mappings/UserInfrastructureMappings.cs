using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
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
