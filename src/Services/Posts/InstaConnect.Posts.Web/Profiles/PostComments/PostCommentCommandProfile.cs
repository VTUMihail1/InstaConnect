using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Web.Models.Responses.PostComments;
using InstaConnect.Posts.Write.Web.Models.Requests.PostComment;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Profiles.PostComments;

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
