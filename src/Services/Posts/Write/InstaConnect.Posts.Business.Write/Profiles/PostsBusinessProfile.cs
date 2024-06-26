using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Models.Users;

namespace InstaConnect.Posts.Business.Profiles;

public class PostsBusinessProfile : Profile
{
    public PostsBusinessProfile()
    {
        // Posts
        CreateMap<CurrentUserDetails, Post>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddPostCommand, Post>();

        CreateMap<UpdatePostCommand, Post>();

        // Post Comments

        CreateMap<CurrentUserDetails, PostComment>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddPostCommentCommand, PostComment>();

        CreateMap<UpdatePostCommentCommand, PostComment>();

        // Post Likes

        CreateMap<CurrentUserDetails, PostLike>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddPostLikeCommand, PostLike>();

        // Post Comment Likes

        CreateMap<CurrentUserDetails, PostComment>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<AddPostCommentLikeCommand, PostCommentLike>();
    }
}
