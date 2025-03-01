using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

public class PostCommandProfile : Profile
{
    public PostCommandProfile()
    {
        CreateMap<Post, PostCommandViewModel>();
    }
}
