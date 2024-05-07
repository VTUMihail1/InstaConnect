using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;
using InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePostComment;
using InstaConnect.Posts.Business.Commands.PostLikes.AddPostLike;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
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
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Profiles;

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

        CreateMap<AddPostCommand, GetCurrentUserRequest>();

        CreateMap<GetCurrentUserResponse, Post>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

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

        CreateMap<AddPostCommentCommand, GetCurrentUserRequest>();

        CreateMap<GetCurrentUserResponse, PostComment>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

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

        CreateMap<AddPostLikeCommand, GetCurrentUserRequest>();

        CreateMap<PostLike, ValidateUserByIdRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

        CreateMap<GetCurrentUserResponse, PostLike>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

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

        CreateMap<AddPostCommentLikeCommand, GetCurrentUserRequest>();

        CreateMap<GetCurrentUserResponse, PostComment>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));

        CreateMap<PostCommentLike, ValidateUserByIdRequest>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

        CreateMap<AddPostCommentLikeCommand, PostCommentLike>();

        CreateMap<PostCommentLike, PostCommentLikeViewDTO>();
    }
}
