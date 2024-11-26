using AutoMapper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entitites;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;

public class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<AddPostCommentLikeCommand, PostCommentLike>()
            .ConstructUsing(src => new(src.PostCommentId, src.CurrentUserId));

        CreateMap<PostCommentLike, PostCommentLikeCommandViewModel>();
    }
}
