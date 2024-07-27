using AutoMapper;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Read.Data.Models.Entities;

namespace InstaConnect.Posts.Business.Profiles.Posts;

public class PostCommandProfile : Profile
{
    public PostCommandProfile()
    {
        CreateMap<AddPostCommand, Post>()
            .ConstructUsing(src => new(src.Title, src.Content, src.CurrentUserId));

        CreateMap<UpdatePostCommand, Post>();

        CreateMap<Post, PostCommandViewModel>();
    }
}
