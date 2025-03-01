using AutoMapper;

using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;

namespace InstaConnect.Posts.Application.Features.PostLikes.Mappings;

public class PostLikeCommandProfile : Profile
{
    public PostLikeCommandProfile()
    {
        CreateMap<PostLike, PostLikeCommandViewModel>();
    }
}
