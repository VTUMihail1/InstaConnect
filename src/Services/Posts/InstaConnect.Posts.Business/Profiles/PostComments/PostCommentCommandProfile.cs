using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Business.Models.PostComment;
using InstaConnect.Posts.Read.Data.Models.Entities;

namespace InstaConnect.Posts.Business.Profiles.PostComments;

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
