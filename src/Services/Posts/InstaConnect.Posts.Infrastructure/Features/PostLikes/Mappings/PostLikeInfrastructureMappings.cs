using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

using Mapster;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Mappings;

internal class PostLikeInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostLikeQueryEntity, PostLike>()
              .ConstructUsing(p => new(
                            p.Id,
                            p.LikeId,
                            new User(
                                p.UserId,
                                p.UserFirstName,
                                p.UserLastName,
                                p.UserEmail,
                                p.UserName,
                                p.UserProfileImage,
                                p.UserCreatedAt,
                                p.UserUpdatedAt),
                            p.CreatedAt,
                            p.UpdatedAt));
    }
}
