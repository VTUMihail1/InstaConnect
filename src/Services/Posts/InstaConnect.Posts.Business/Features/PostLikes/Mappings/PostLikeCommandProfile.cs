using AutoMapper;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Data.Features.PostLikes.Models.Entitites;

namespace InstaConnect.Posts.Business.Features.PostLikes.Mappings;

public class PostLikeCommandProfile : Profile
{
    public PostLikeCommandProfile()
    {
        CreateMap<AddPostLikeCommand, PostLike>()
            .ConstructUsing(src => new(src.PostId, src.CurrentUserId));

        CreateMap<PostLike, PostLikeCommandViewModel>();
    }
}
