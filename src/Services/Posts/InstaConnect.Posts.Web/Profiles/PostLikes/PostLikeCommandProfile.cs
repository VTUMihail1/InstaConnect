using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;
using InstaConnect.Posts.Business.Models.PostLike;
using InstaConnect.Posts.Read.Web.Models.Responses;
using InstaConnect.Posts.Write.Web.Models.Requests.PostLike;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Profiles.PostLikes;

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
