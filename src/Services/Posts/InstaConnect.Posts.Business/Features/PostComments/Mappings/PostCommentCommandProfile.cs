using AutoMapper;
using InstaConnect.Posts.Business.Features.PostComments.Commands.AddPostComment;
using InstaConnect.Posts.Business.Features.PostComments.Commands.UpdatePostComment;
using InstaConnect.Posts.Business.Features.PostComments.Models;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;

namespace InstaConnect.Posts.Business.Features.PostComments.Mappings;

public class PostCommentCommandProfile : Profile
{
    public PostCommentCommandProfile()
    {
        CreateMap<AddPostCommentCommand, PostComment>()
            .ConstructUsing(src => new(src.CurrentUserId, src.PostId, src.Content));

        CreateMap<UpdatePostCommentCommand, PostComment>();

        CreateMap<PostComment, PostCommentCommandViewModel>();
    }
}
