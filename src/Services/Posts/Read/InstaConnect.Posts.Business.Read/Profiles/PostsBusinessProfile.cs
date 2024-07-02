﻿using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Business.Read.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Read.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Posts.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Read.Profiles;

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

        CreateMap<GetAllPostsQuery, CollectionQuery>();

        CreateMap<Post, PostViewModel>();

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

        CreateMap<GetAllPostCommentsQuery, CollectionQuery>();

        CreateMap<PostComment, PostCommentViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

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

        CreateMap<GetAllPostLikesQuery, CollectionQuery>();

        CreateMap<PostLike, PostLikeViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

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

        CreateMap<GetAllPostCommentLikesQuery, CollectionQuery>();

        CreateMap<PostCommentLike, PostCommentLikeViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
    }
}
