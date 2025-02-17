using AutoMapper;

using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;

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
