using AutoMapper;

using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Events;

using Mapster;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Mappings;

internal class PostLikeDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PostLike, PostLikeAddedEvent>()
            .ConstructUsing(p => new(
                p.Id,
                p.LikeId,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<PostLike, PostLikeDeletedEvent>()
            .ConstructUsing(p => new(p.Id, p.LikeId));
    }
}
