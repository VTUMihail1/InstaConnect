using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Read.Data.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Profiles;

public class PostsBusinessProfile : Profile
{
    public PostsBusinessProfile()
    {
        // Posts

        CreateMap<UserDeletedEvent, PostFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostFilteredCollectionQuery
                 {
                     Expression = p => p.UserId == src.Id
                 });

        CreateMap<GetAllFilteredPostsQuery, PostFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostFilteredCollectionQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.Title == string.Empty || p.Title == src.Title)
                 });

        CreateMap<GetAllPostsQuery, CollectionReadQuery>();

        CreateMap<Post, PostViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));

        // Post Comments

        CreateMap<UserDeletedEvent, PostCommentFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostCommentFilteredCollectionQuery
                 {
                     Expression = p => p.UserId == src.Id
                 });

        CreateMap<GetAllFilteredPostCommentsQuery, PostCommentFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostCommentFilteredCollectionQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.PostId == string.Empty || p.PostId == src.PostId)
                 });

        CreateMap<GetAllPostCommentsQuery, CollectionReadQuery>();

        CreateMap<PostComment, PostCommentViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));

        // Post Likes

        CreateMap<UserDeletedEvent, PostLikeFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostLikeFilteredCollectionQuery
                 {
                     Expression = p => p.UserId == src.Id
                 });

        CreateMap<GetAllFilteredPostLikesQuery, PostLikeFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostLikeFilteredCollectionQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.PostId == string.Empty || p.PostId == src.PostId)
                 });

        CreateMap<GetAllPostLikesQuery, CollectionReadQuery>();

        CreateMap<PostLike, PostLikeViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));

        // Post Comment Likes

        CreateMap<UserDeletedEvent, PostCommentLikeFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostCommentLikeFilteredCollectionQuery
                 {
                     Expression = p => p.UserId == src.Id
                 });

        CreateMap<GetAllFilteredPostCommentLikesQuery, PostCommentLikeFilteredCollectionQuery>()
            .ConstructUsing(src =>
                 new PostCommentLikeFilteredCollectionQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.PostCommentId == string.Empty || p.PostCommentId == src.PostCommentId)
                 });

        CreateMap<GetAllPostCommentLikesQuery, CollectionReadQuery>();

        CreateMap<PostCommentLike, PostCommentLikeViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));
    }
}
