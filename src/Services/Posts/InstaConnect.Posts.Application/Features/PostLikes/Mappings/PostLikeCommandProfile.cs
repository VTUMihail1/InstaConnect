using AutoMapper;

using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

namespace InstaConnect.Posts.Application.Features.PostLikes.Mappings;

public class PostLikeCommandProfile : Profile
{
    public PostLikeCommandProfile()
    {
        CreateMap<AddPostLikeCommand, PostLike>()
            .ConstructUsing(src => new(src.PostId, src.CurrentUserId));

        CreateMap<PostLike, PostLikeCommandViewModel>();
    }
}
