using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetPostCommentLikeById;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Read.Business.Queries.PostComments.GetPostCommentById;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Read.Business.Queries.PostLikes.GetPostLikeById;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Read.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Read.Web.Models.Requests.Post;
using InstaConnect.Posts.Read.Web.Models.Requests.PostComment;
using InstaConnect.Posts.Read.Web.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Read.Web.Models.Requests.PostLike;
using InstaConnect.Posts.Read.Web.Models.Responses;

namespace InstaConnect.Posts.Read.Web.Profiles;

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
