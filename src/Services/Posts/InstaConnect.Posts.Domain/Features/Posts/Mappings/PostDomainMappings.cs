using AutoMapper;

using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Events;

using Mapster;

namespace InstaConnect.Posts.Domain.Features.Posts.Mappings;

internal class PostDomainMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, AddedPostEvent>()
            .ConstructUsing(p => new(
                p.Id,
                p.Title,
                p.Content,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<Post, UpdatedPostEvent>()
            .ConstructUsing(p => new(
                p.Id,
                p.Title,
                p.Content,
                p.UserId,
                p.CreatedAt,
                p.UpdatedAt));

        config.NewConfig<Post, DeletedPostEvent>()
            .ConstructUsing(p => new(p.Id));
    }
}
