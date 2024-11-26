using AutoMapper;
using InstaConnect.Posts.Application.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Application.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Application.Features.Posts.Models;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;

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
