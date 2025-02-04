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
        CreateMap<AddPostCommentRequest, AddPostCommentCommand>()
            .ConstructUsing(src => new(src.CurrentUserId, src.Body.PostId, src.Body.Content));

        CreateMap<UpdatePostCommentRequest, UpdatePostCommentCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId, src.Body.Content));

        CreateMap<DeletePostCommentRequest, DeletePostCommentCommand>()
            .ConstructUsing(src => new(src.Id, src.CurrentUserId));

        CreateMap<PostCommentCommandViewModel, PostCommentCommandResponse>();
    }
}
