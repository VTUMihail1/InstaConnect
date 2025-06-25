using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;

using Mapster;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

public class PostApplicationRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Post, AddPostCommandResponse>()
              .MapWith(p => new AddPostCommandResponse(new(p.Id, p.CreatedAt, p.UpdatedAt)));

        config.NewConfig<Post, UpdatePostCommandResponse>()
              .MapWith(p => new UpdatePostCommandResponse(new(p.Id, p.CreatedAt, p.UpdatedAt)));
    }
}
