using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

public class PostCommandProfile : Profile
{
    public PostCommandProfile()
    {
        CreateMap<Post, AddPostCommandResponse>()
            .ConstructUsing(p => new(new(p.Id)));

        CreateMap<Post, UpdatePostCommandResponse>()
            .ConstructUsing(p => new(new(p.Id)));
    }
}
