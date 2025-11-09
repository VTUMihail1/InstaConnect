using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Mappings;

internal class PostLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostLike, PostLikeAddedEventRequest>()
            .ConstructUsing(p => new(
                p.Id,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<PostLike, PostLikeDeletedEventRequest>()
            .ConstructUsing(p => new(p.Id, p.UserId));
    }
}
