using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;

namespace InstaConnect.Posts.Application.Features.Posts.Mappings;

public class PostCommandProfile : Profile
{
    public PostCommandProfile()
    {
        CreateMap<AddPostCommand, Post>()
            .ConstructUsing(src => new(src.Title, src.Content, src.CurrentUserId));

        CreateMap<UpdatePostCommand, Post>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Post, PostCommandViewModel>();
    }
}
