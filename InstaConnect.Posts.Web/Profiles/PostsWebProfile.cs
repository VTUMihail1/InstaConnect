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
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;
using InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;
using InstaConnect.Posts.Business.Queries.PostComments.GetAllPostComments;
using InstaConnect.Posts.Business.Queries.PostComments.GetPostCommentById;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllFilteredPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;
using InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Web.Models.Requests.Post;
using InstaConnect.Posts.Web.Models.Requests.PostComment;
using InstaConnect.Posts.Web.Models.Requests.PostCommentLike;
using InstaConnect.Posts.Web.Models.Requests.PostLike;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Posts.Web.Profiles
{
    public class PostsWebProfile : Profile
    {
        public PostsWebProfile()
        {
            // Posts

            CreateMap<CollectionRequestModel, GetAllPostsQuery>();

            CreateMap<GetPostsCollectionRequestModel, GetAllFilteredPostsQuery>();

            CreateMap<GetPostByIdRequestModel, GetPostByIdQuery>();

            CreateMap<AddPostRequestModel, AddPostCommand>();

            CreateMap<UpdatePostRequestModel, UpdatePostCommand>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.UpdatePostBodyRequestModel.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.UpdatePostBodyRequestModel.Content));

            CreateMap<DeletePostRequestModel, DeletePostCommand>();

            // Post Comments

            CreateMap<CollectionRequestModel, GetAllPostCommentsQuery>();

            CreateMap<GetPostCommentsCollectionRequestModel, GetAllFilteredPostCommentsQuery>();

            CreateMap<GetPostCommentByIdRequestModel, GetPostCommentByIdQuery>();

            CreateMap<AddPostCommentRequestModel, AddPostCommentCommand>();

            CreateMap<UpdatePostCommentRequestModel, UpdatePostCommentCommand>();

            CreateMap<DeletePostCommentRequestModel, DeletePostCommentCommand>();

            // Post Likes

            CreateMap<CollectionRequestModel, GetAllPostLikesQuery>();

            CreateMap<GetPostLikesCollectionRequestModel, GetAllFilteredPostLikesQuery>();

            CreateMap<GetPostLikeByIdRequestModel, GetPostLikeByIdQuery>();

            CreateMap<AddPostLikeRequestModel, AddPostLikeCommand>();

            CreateMap<DeletePostLikeRequestModel, DeletePostLikeCommand>();

            // Post Comment Likes

            CreateMap<CollectionRequestModel, GetAllPostCommentLikesQuery>();

            CreateMap<GetPostCommentLikesCollectionRequestModel, GetAllFilteredPostCommentLikesQuery>();

            CreateMap<GetPostCommentLikeByIdRequestModel, GetPostCommentLikeByIdQuery>();

            CreateMap<AddPostCommentLikeRequestModel, AddPostCommentLikeCommand>();

            CreateMap<DeletePostCommentLikeRequestModel, DeletePostCommentLikeCommand>();
        }
    }
}
