using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Mappings;

internal class PostLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostLike, PostLikeAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostLikeIdEventPayload>(),
                src.CreatedAtUtc));

        config.NewConfig<PostLike, PostLikeDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<PostLikeIdEventPayload>()));

        config.NewConfig<PostLikeId, PostLikeIdEventPayload>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdEventPayload>(),
                                     src.UserId.Adapt<UserIdEventPayload>()));
    }
}
