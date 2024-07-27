using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Posts.Read.Data.Models.Entities;

namespace InstaConnect.Posts.Business.Profiles.PostLikes;

public class PostLikeCommandProfile : Profile
{
    public PostLikeCommandProfile()
    {
        CreateMap<AddPostLikeCommand, PostLike>()
            .ConstructUsing(src => new(src.PostId, src.CurrentUserId));

        CreateMap<PostLike, PostLikeCommandViewModel>();
    }
}
