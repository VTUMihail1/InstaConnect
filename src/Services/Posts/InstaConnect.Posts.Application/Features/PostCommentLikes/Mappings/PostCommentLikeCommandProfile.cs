using AutoMapper;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Mappings;

public class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<AddPostCommentLikeCommand, PostCommentLike>()
            .ConstructUsing(src => new(src.PostCommentId, src.CurrentUserId));

        CreateMap<PostCommentLike, PostCommentLikeCommandViewModel>();
    }
}
