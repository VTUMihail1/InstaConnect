using InstaConnect.Identity.Events.Features.Users;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.Posts.Mappings;

internal class PostDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, PostAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdEventPayload>(),
                src.Title,
                src.Content,
                src.UserId.Adapt<UserIdEventPayload>(),
                src.CreatedAt,
                src.UpdatedAt));

        config.NewConfig<Post, PostUpdatedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Adapt<PostIdEventPayload>(),
                src.Title,
                src.Content,
                src.UserId.Adapt<UserIdEventPayload>(),
                src.CreatedAt,
                src.UpdatedAt));

        config.NewConfig<Post, PostDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Adapt<PostIdEventPayload>()));

        config.NewConfig<PostId, PostIdEventPayload>()
            .ConstructUsing(src => new(src.Id));
    }
}
