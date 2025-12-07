using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Mappings;

internal class PostLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostLike, PostLikeAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.UserId.Id,
                src.CreatedAtUtc));

        config.NewConfig<PostLike, PostLikeDeletedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id.Id,
                src.Id.UserId.Id));
    }
}
