using AutoMapper;
using InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Write.Business.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Write.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.DeletePostComment;
using InstaConnect.Posts.Write.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Write.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Write.Business.Commands.PostLikes.DeletePostLike;
using InstaConnect.Posts.Write.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Write.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Write.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Write.Web.Models.Requests.Post;
using InstaConnect.Posts.Write.Web.Models.Requests.PostComment;
using InstaConnect.Posts.Write.Web.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Write.Web.Models.Requests.PostLike;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Write.Web.Profiles;

public class PostsWebProfile : Profile
{
    public PostsWebProfile()
    {
        // Posts

        CreateMap<AddPostRequest, AddPostCommand>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.AddPostBindingModel.Title))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.AddPostBindingModel.Content));

        CreateMap<CurrentUserModel, AddPostCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<UpdatePostRequest, UpdatePostCommand>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.UpdatePostBindingModel.Title))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.UpdatePostBindingModel.Content));

        CreateMap<CurrentUserModel, UpdatePostCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeletePostRequest, DeletePostCommand>();

        CreateMap<CurrentUserModel, DeletePostCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        // Post Likes

        CreateMap<AddPostLikeRequest, AddPostLikeCommand>()
            .ForMember(dest => dest.PostId, opt => opt.MapFrom(src => src.AddPostLikeBindingModel.PostId));

        CreateMap<CurrentUserModel, AddPostLikeCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeletePostLikeRequest, DeletePostLikeCommand>();

        CreateMap<CurrentUserModel, DeletePostLikeCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        // Post Comments

        CreateMap<AddPostCommentRequest, AddPostCommentCommand>()
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.AddPostCommentBindingModel.Content));

        CreateMap<CurrentUserModel, AddPostCommentCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<UpdatePostCommentRequest, UpdatePostCommentCommand>()
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.UpdatePostCommentBindingModel.Content));

        CreateMap<CurrentUserModel, UpdatePostCommentCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeletePostCommentRequest, DeletePostCommentCommand>();

        CreateMap<CurrentUserModel, DeletePostCommentCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        // Post Comment Likes

        CreateMap<AddPostCommentLikeRequest, AddPostCommentLikeCommand>()
            .ForMember(dest => dest.PostCommentId, opt => opt.MapFrom(src => src.AddPostCommentLikeBindingModel.PostId));

        CreateMap<CurrentUserModel, AddPostCommentLikeCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<DeletePostCommentLikeRequest, DeletePostCommentLikeCommand>();

        CreateMap<CurrentUserModel, DeletePostCommentLikeCommand>()
            .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.Id));
    }
}
