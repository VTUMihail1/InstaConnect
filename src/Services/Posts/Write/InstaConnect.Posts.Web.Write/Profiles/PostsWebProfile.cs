using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Commands.PostLikes.DeletePostLike;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Web.Models.Requests.Post;
using InstaConnect.Posts.Web.Models.Requests.PostComment;
using InstaConnect.Posts.Web.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Models.Requests.PostLike;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Posts.Web.Profiles;

public class PostsWebProfile : Profile
{
    public PostsWebProfile()
    {
        // Posts

        CreateMap<AddPostRequest, AddPostCommand>();

        CreateMap<UpdatePostRequest, UpdatePostCommand>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.UpdatePostBodyRequest.Title))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.UpdatePostBodyRequest.Content));

        CreateMap<DeletePostRequest, DeletePostCommand>();

        // Post Likes

        CreateMap<AddPostLikeRequest, AddPostLikeCommand>();

        CreateMap<DeletePostLikeRequest, DeletePostLikeCommand>();

        // Post Comments

        CreateMap<AddPostCommentRequest, AddPostCommentCommand>();

        CreateMap<UpdatePostCommentRequest, UpdatePostCommentCommand>();

        CreateMap<DeletePostCommentRequest, DeletePostCommentCommand>();

        // Post Comment Likes

        CreateMap<AddPostCommentLikeRequest, AddPostCommentLikeCommand>();

        CreateMap<DeletePostCommentLikeRequest, DeletePostCommentLikeCommand>();
    }
}
