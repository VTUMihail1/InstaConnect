using AutoMapper;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.AddPostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Commands.DeletePostLike;
using InstaConnect.Posts.Business.Features.PostLikes.Models;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Web.Features.PostLikes.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Features.PostLikes.Mappings;

internal class PostLikeCommandProfile : Profile
{
    public PostLikeCommandProfile()
    {
        CreateMap<(CurrentUserModel, AddPostLikeRequest), AddPostLikeCommand>()
            .ConstructUsing(src => new(src.Item1.Id, src.Item2.AddPostLikeBindingModel.PostId));

        CreateMap<(CurrentUserModel, DeletePostLikeRequest), DeletePostLikeCommand>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item1.Id));

        CreateMap<PostLikeCommandViewModel, PostLikeCommandResponse>();
    }
}
