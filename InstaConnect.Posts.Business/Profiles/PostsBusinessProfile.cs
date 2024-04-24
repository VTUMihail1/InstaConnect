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
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Profiles
{
    public class PostsBusinessProfile : Profile
    {
        public PostsBusinessProfile()
        {
            // Posts

            CreateMap<GetAllFilteredPostsQuery, PostFilteredCollectionQuery>()
                .ConstructUsing(src =>
                     new PostFilteredCollectionQuery
                     {
                         Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                           (src.Title == string.Empty || p.Title == src.Title)
                     });

            CreateMap<GetAllPostsQuery, CollectionQuery>();

            CreateMap<AddPostCommand, GetUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UpdatePostCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<DeletePostCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Post, ValidateUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<AddPostCommand, Post>();

            CreateMap<UpdatePostCommand, Post>();

            CreateMap<Post, PostViewDTO>();

            // Post Comments

            CreateMap<GetAllFilteredPostCommentsQuery, PostCommentFilteredCollectionQuery>()
                .ConstructUsing(src =>
                     new PostCommentFilteredCollectionQuery
                     {
                         Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                           (src.PostId == string.Empty || p.PostId == src.PostId) &&
                                           (src.PostCommentId == string.Empty || p.PostCommentId == src.PostCommentId)
                     });

            CreateMap<GetAllPostCommentsQuery, CollectionQuery>();

            CreateMap<AddPostCommentCommand, GetUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UpdatePostCommentCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<DeletePostCommentCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<PostComment, ValidateUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<AddPostCommentCommand, PostComment>();

            CreateMap<UpdatePostCommentCommand, PostComment>();

            CreateMap<PostComment, PostCommentViewDTO>();

            // Post Likes

            CreateMap<GetAllFilteredPostLikesQuery, PostLikeFilteredCollectionQuery>()
                .ConstructUsing(src =>
                     new PostLikeFilteredCollectionQuery
                     {
                         Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                           (src.PostId == string.Empty || p.PostId == src.PostId)
                     });

            CreateMap<GetAllPostLikesQuery, CollectionQuery>();

            CreateMap<AddPostLikeCommand, GetUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<DeletePostLikeCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<PostLike, ValidateUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<AddPostLikeCommand, PostLike>();

            CreateMap<PostLike, PostLikeViewDTO>();

            // Post Comment Likes

            CreateMap<GetAllFilteredPostCommentLikesQuery, PostCommentLikeFilteredCollectionQuery>()
                .ConstructUsing(src =>
                     new PostCommentLikeFilteredCollectionQuery
                     {
                         Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                           (src.PostCommentId == string.Empty || p.PostCommentId == src.PostCommentId)
                     });

            CreateMap<GetAllPostCommentLikesQuery, CollectionQuery>();

            CreateMap<AddPostCommentLikeCommand, GetUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<DeletePostCommentLikeCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<PostCommentLike, ValidateUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<AddPostCommentLikeCommand, PostCommentLike>();

            CreateMap<PostCommentLike, PostCommentLikeViewDTO>();
        }
    }
}
