using AutoMapper;
using InstaConnect.Posts.Business.Commands.PostComments.AddPost;
using InstaConnect.Posts.Business.Commands.PostComments.DeletePost;
using InstaConnect.Posts.Business.Commands.PostComments.UpdatePost;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Web.Models.Requests.Post;
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
