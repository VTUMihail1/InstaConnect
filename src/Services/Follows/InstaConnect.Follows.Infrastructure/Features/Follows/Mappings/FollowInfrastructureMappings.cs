using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Follows.Infrastructure.Features.Follows.Models;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using Mapster;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Mappings;

internal class FollowInfrastructureMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<FollowQueryEntity, Follow>()
              .ConstructUsing(pl => new(
                            new User(
                                pl.FollowerId,
                                pl.FollowerFirstName,
                                pl.FollowerLastName,
                                pl.FollowerEmail,
                                pl.FollowerName,
                                pl.FollowerProfileImage,
                                pl.FollowerCreatedAt,
                                pl.FollowerUpdatedAt),
                            new User(
                                pl.FollowingId,
                                pl.FollowingFirstName,
                                pl.FollowingLastName,
                                pl.FollowingEmail,
                                pl.FollowingName,
                                pl.FollowingProfileImage,
                                pl.FollowingCreatedAt,
                                pl.FollowingUpdatedAt),
                            pl.CreatedAt,
                            pl.UpdatedAt));
    }
}
