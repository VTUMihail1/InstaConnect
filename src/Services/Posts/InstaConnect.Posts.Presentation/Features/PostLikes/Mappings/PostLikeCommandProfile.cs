using AutoMapper;

using InstaConnect.Posts.Application.Features.PostLikes.Commands.Add;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.Delete;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Mappings;

internal class PostLikeCommandProfile : Profile
{
    public PostLikeCommandProfile()
    {
        CreateMap<AddPostLikeRequest, AddPostLikeCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.Body.PostId));

        CreateMap<DeletePostLikeRequest, DeletePostLikeCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId));

        CreateMap<PostLikeCommandViewModel, PostLikeCommandResponse>();
    }
}
