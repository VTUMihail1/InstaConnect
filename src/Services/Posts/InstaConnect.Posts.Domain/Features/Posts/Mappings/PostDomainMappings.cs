using Mapster;

namespace InstaConnect.Posts.Domain.Features.Posts.Mappings;

internal class PostDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, PostAddedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.Title,
                src.Content,
                src.UserId.Id,
                src.CreatedAtUtc,
                src.UpdatedAtUtc));

        config.NewConfig<Post, PostUpdatedEventRequest>()
            .ConstructUsing(src => new(
                src.Id.Id,
                src.Title,
                src.Content,
                src.UserId.Id,
                src.UpdatedAtUtc));

        config.NewConfig<Post, PostDeletedEventRequest>()
            .ConstructUsing(src => new(src.Id.Id));
    }
}
