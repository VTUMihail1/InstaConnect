﻿using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetPostCommentLikeById;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Business.Read.Queries.PostComments.GetPostCommentById;
using InstaConnect.Posts.Business.Read.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Read.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Business.Read.Queries.PostLikes.GetPostLikeById;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Read.Queries.Posts.GetPostById;
using InstaConnect.Posts.Web.Read.Models.Requests.Post;
using InstaConnect.Posts.Web.Read.Models.Requests.PostComment;
using InstaConnect.Posts.Web.Read.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Read.Models.Requests.PostLike;
using InstaConnect.Posts.Web.Read.Models.Responses;

namespace InstaConnect.Posts.Web.Read.Profiles;

public class PostsWebProfile : Profile
{
    public PostsWebProfile()
    {
        // Posts

        CreateMap<GetAllPostsRequest, GetAllPostsQuery>();

        CreateMap<GetAllFilteredPostsRequest, GetAllFilteredPostsQuery>();

        CreateMap<GetPostByIdRequest, GetPostByIdQuery>();

        CreateMap<PostViewModel, PostResponse>();

        // Post Comments

        CreateMap<GetAllPostCommentsRequest, GetAllPostCommentsQuery>();

        CreateMap<GetAllFilteredPostCommentsRequest, GetAllFilteredPostCommentsQuery>();

        CreateMap<GetPostCommentByIdRequest, GetPostCommentByIdQuery>();

        CreateMap<PostCommentViewModel, PostCommentResponse>();

        // Post Likes

        CreateMap<GetAllPostLikesRequest, GetAllPostLikesQuery>();

        CreateMap<GetAllFilteredPostLikesRequest, GetAllFilteredPostLikesQuery>();

        CreateMap<GetPostLikeByIdRequest, GetPostLikeByIdQuery>();

        CreateMap<PostLikeViewModel, PostLikeResponse>();

        // Post Comment Likes

        CreateMap<GetAllPostCommentLikesRequest, GetAllPostCommentLikesQuery>();

        CreateMap<GetAllFilteredPostCommentLikesRequest, GetAllFilteredPostCommentLikesQuery>();

        CreateMap<GetPostCommentLikeByIdRequest, GetPostCommentLikeByIdQuery>();

        CreateMap<PostCommentLikeViewModel, PostCommentLikeResponse>();
    }
}
