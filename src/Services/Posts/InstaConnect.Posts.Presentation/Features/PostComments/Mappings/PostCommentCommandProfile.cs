using AutoMapper;
using InstaConnect.Posts.Application.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Application.Features.PostComments.Commands.DeletePostComment;
using InstaConnect.Posts.Application.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;
using InstaConnect.Shared.Presentation.Models.Users;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Mappings;

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
