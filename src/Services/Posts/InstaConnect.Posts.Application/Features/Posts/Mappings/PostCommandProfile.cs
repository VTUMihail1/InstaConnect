using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Commands.AddPost;
using InstaConnect.Posts.Business.Features.Posts.Commands.UpdatePost;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;

namespace InstaConnect.Posts.Business.Features.Posts.Mappings;

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
