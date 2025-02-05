using AutoMapper;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Application.Features.PostLikes.Commands.DeletePostLike;
using InstaConnect.Posts.Application.Features.PostLikes.Models;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

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
