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

public class PostsWebQueryProfile : Profile
{
    public PostsWebQueryProfile()
    {
        // Posts

        CreateMap<GetAllPostsRequest, GetAllPostsQuery>();

        CreateMap<GetAllFilteredPostsRequest, GetAllFilteredPostsQuery>();

        CreateMap<GetPostByIdRequest, GetPostByIdQuery>();

        CreateMap<PostQueryViewModel, PostQueryResponse>();

        // Post Comments

        CreateMap<GetAllPostCommentsRequest, GetAllPostCommentsQuery>();

        CreateMap<GetAllFilteredPostCommentsRequest, GetAllFilteredPostCommentsQuery>();

        CreateMap<GetPostCommentByIdRequest, GetPostCommentByIdQuery>();

        CreateMap<PostCommentQueryViewModel, PostCommentQueryResponse>();

        // Post Likes

        CreateMap<GetAllPostLikesRequest, GetAllPostLikesQuery>();

        CreateMap<GetAllFilteredPostLikesRequest, GetAllFilteredPostLikesQuery>();

        CreateMap<GetPostLikeByIdRequest, GetPostLikeByIdQuery>();

        CreateMap<PostLikeQueryViewModel, PostLikeQueryResponse>();

        // Post Comment Likes

        CreateMap<GetAllPostCommentLikesRequest, GetAllPostCommentLikesQuery>();

        CreateMap<GetAllFilteredPostCommentLikesRequest, GetAllFilteredPostCommentLikesQuery>();

        CreateMap<GetPostCommentLikeByIdRequest, GetPostCommentLikeByIdQuery>();

        CreateMap<PostCommentLikeQueryViewModel, PostCommentLikeQueryResponse>();
    }
}
