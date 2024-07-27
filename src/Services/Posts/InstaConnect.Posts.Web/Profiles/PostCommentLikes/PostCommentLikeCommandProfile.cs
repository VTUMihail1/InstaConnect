using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Web.Models.Responses.PostCommentLikes;
using InstaConnect.Posts.Write.Web.Models.Requests.PostCommentLike;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Profiles.PostCommentLikes;

internal class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<(CurrentUserModel, AddPostCommentLikeRequest), AddPostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Item1.Id, src.Item2.AddPostCommentLikeBindingModel.PostId));

        CreateMap<(CurrentUserModel, DeletePostCommentLikeRequest), DeletePostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item1.Id));

        CreateMap<PostCommentLikeCommandViewModel, PostCommentLikeCommandResponse>();
    }
}
