using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Read.Data.Models.Entities;

namespace InstaConnect.Posts.Business.Profiles.PostCommentLikes;

public class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<AddPostCommentLikeCommand, PostCommentLike>()
            .ConstructUsing(src => new(src.PostCommentId, src.CurrentUserId));

        CreateMap<PostCommentLike, PostCommentLikeCommandViewModel>();
    }
}
