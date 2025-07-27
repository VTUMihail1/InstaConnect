using AutoMapper;

using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;

internal class PostLikeCommandProfile : Profile
{
    public PostLikeCommandProfile()
    {
        CreateMap<AddPostLikeRequest, AddPostLikeCommandRequest>()
            .ConstructUsing(src => new(src.CurrentUserId, src.PostId));

        CreateMap<DeletePostLikeRequest, DeletePostLikeCommandRequest>()
            .ConstructUsing(src => new(src.Id, src.PostId, src.CurrentUserId));

        CreateMap<PostLikeCommandViewModel, PostLikeCommandResponse>();
    }
}
