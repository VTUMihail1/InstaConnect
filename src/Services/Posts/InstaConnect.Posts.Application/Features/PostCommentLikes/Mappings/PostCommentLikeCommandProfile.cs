using AutoMapper;

using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.Add;

namespace InstaConnect.Posts.Application.Features.PostCommentLikes.Mappings;

public class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<PostCommentLike, PostCommentLikeCommandViewModel>();
    }
}
