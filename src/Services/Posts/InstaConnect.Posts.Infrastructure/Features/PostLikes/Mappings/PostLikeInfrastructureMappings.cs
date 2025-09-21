using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;

using Mapster;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Mappings;

internal class PostLikeInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostLikeQueryEntity, PostLike>()
              .ConstructUsing(pl => new(
                            pl.Id,
                            new User(
                                pl.UserId,
                                pl.UserFirstName,
                                pl.UserLastName,
                                pl.UserEmail,
                                pl.UserName,
                                pl.UserProfileImage,
                                pl.UserCreatedAt,
                                pl.UserUpdatedAt),
                            pl.CreatedAt,
                            pl.UpdatedAt));
    }
}
