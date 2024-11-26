using AutoMapper;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.AddPostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Commands.DeletePostCommentLike;
using InstaConnect.Posts.Application.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Mappings;

internal class PostCommentLikeCommandProfile : Profile
{
    public PostCommentLikeCommandProfile()
    {
        CreateMap<(CurrentUserModel, AddPostCommentLikeRequest), AddPostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Item1.Id, src.Item2.AddPostCommentLikeBindingModel.PostCommentId));

        CreateMap<(CurrentUserModel, DeletePostCommentLikeRequest), DeletePostCommentLikeCommand>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item1.Id));

        CreateMap<PostCommentLikeCommandViewModel, PostCommentLikeCommandResponse>();
    }
}
