using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Write.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Write.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Write.Business.Commands.Posts.UpdatePost;

namespace InstaConnect.Posts.Write.Business.Profiles;

public class PostsCommandProfile : Profile
{
    public PostsCommandProfile()
    {
        // Posts

        CreateMap<AddPostCommand, Post>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<UpdatePostCommand, Post>();

        CreateMap<Post, PostCommandViewModel>();

        // Post Comments

        CreateMap<AddPostCommentCommand, PostComment>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<UpdatePostCommentCommand, PostComment>();

        CreateMap<PostComment, PostCommentCommandViewModel>();

        // Post Likes

        CreateMap<AddPostLikeCommand, PostLike>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<PostLike, PostLikeCommandViewModel>();

        // Post Comment Likes

        CreateMap<AddPostCommentLikeCommand, PostCommentLike>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CurrentUserId));

        CreateMap<PostCommentLike, PostCommentLikeCommandViewModel>();
    }
}
