using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.DeletePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Web.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Web.Features.PostComments.Models.Responses;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Features.PostComments.Mappings;

internal class PostCommentCommandProfile : Profile
{
    public PostCommentCommandProfile()
    {
        CreateMap<(CurrentUserModel, AddPostCommentRequest), AddPostCommentCommand>()
            .ConstructUsing(src => new(src.Item1.Id, src.Item2.AddPostCommentBindingModel.PostId, src.Item2.AddPostCommentBindingModel.Content));

        CreateMap<(CurrentUserModel, UpdatePostCommentRequest), UpdatePostCommentCommand>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item1.Id, src.Item2.UpdatePostCommentBindingModel.Content));

        CreateMap<(CurrentUserModel, DeletePostCommentRequest), DeletePostCommentCommand>()
            .ConstructUsing(src => new(src.Item2.Id, src.Item1.Id));

        CreateMap<PostCommentCommandViewModel, PostCommentCommandResponse>();
    }
}
