using AutoMapper;
using InstaConnect.Posts.Business.Write.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Write.Commands.PostCommentLikes.DeletePostCommentLike;
using InstaConnect.Posts.Business.Write.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Business.Write.Commands.PostComments.DeletePostComment;
using InstaConnect.Posts.Business.Write.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Business.Write.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Write.Commands.PostLikes.DeletePostLike;
using InstaConnect.Posts.Business.Write.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Write.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Write.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Web.Write.Models.Requests.Post;
using InstaConnect.Posts.Web.Write.Models.Requests.PostComment;
using InstaConnect.Posts.Web.Write.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Write.Models.Requests.PostLike;
using InstaConnect.Shared.Web.Models.Users;

namespace InstaConnect.Posts.Web.Write.Profiles;

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
