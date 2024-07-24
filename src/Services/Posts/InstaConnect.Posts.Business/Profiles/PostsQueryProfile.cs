using AutoMapper;
using InstaConnect.Posts.Data.Models.Filters.PostCommentLikes;
using InstaConnect.Posts.Data.Models.Filters.PostComments;
using InstaConnect.Posts.Data.Models.Filters.PostLikes;
using InstaConnect.Posts.Data.Models.Filters.Posts;
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
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Profiles;

public class PostsQueryProfile : Profile
{
    public PostsQueryProfile()
    {
        // Posts

        CreateMap<GetAllFilteredPostsQuery, PostFilteredCollectionReadQuery>()
            .ConstructUsing(src =>
                 new PostFilteredCollectionReadQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.Title == string.Empty || p.Title == src.Title)
                 });

        CreateMap<GetAllPostsQuery, CollectionReadQuery>();

        CreateMap<Post, PostQueryViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));

        // Post Comments

        CreateMap<GetAllFilteredPostCommentsQuery, PostCommentFilteredCollectionReadQuery>()
            .ConstructUsing(src =>
                 new PostCommentFilteredCollectionReadQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.PostId == string.Empty || p.PostId == src.PostId)
                 });

        CreateMap<GetAllPostCommentsQuery, CollectionReadQuery>();

        CreateMap<PostComment, PostCommentQueryViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));

        // Post Likes

        CreateMap<GetAllFilteredPostLikesQuery, PostLikeFilteredCollectionReadQuery>()
            .ConstructUsing(src =>
                 new PostLikeFilteredCollectionReadQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.PostId == string.Empty || p.PostId == src.PostId)
                 });

        CreateMap<GetAllPostLikesQuery, CollectionReadQuery>();

        CreateMap<PostLike, PostLikeQueryViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));

        // Post Comment Likes

        CreateMap<GetAllFilteredPostCommentLikesQuery, PostCommentLikeFilteredCollectionReadQuery>()
            .ConstructUsing(src =>
                 new PostCommentLikeFilteredCollectionReadQuery
                 {
                     Expression = p => (src.UserId == string.Empty || p.UserId == src.UserId) &&
                                       (src.UserName == string.Empty || p.User.UserName == src.UserName) &&
                                       (src.PostCommentId == string.Empty || p.PostCommentId == src.PostCommentId)
                 });

        CreateMap<GetAllPostCommentLikesQuery, CollectionReadQuery>();

        CreateMap<PostCommentLike, PostCommentLikeQueryViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.UserProfileImage, opt => opt.MapFrom(src => src.User.ProfileImage));
    }
}
