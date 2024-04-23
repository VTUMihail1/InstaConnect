using AutoMapper;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Business.Queries.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.GetAllPosts;
using InstaConnect.Posts.Business.Queries.GetPostById;
using InstaConnect.Posts.Web.Models.Requests;
using InstaConnect.Shared.Web.Models.Filters;

namespace InstaConnect.Posts.Web.Profiles
{
    public class PostsWebProfile : Profile
    {
        public PostsWebProfile()
        {
            CreateMap<CollectionRequestModel, GetAllPostsQuery>();

            CreateMap<GetPostsCollectionRequestModel, GetAllFilteredPostsQuery>();

            CreateMap<GetPostByIdRequestModel, GetPostByIdQuery>();

            CreateMap<AddPostRequestModel, AddPostCommand>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.AddPostBodyRequestModel.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.AddPostBodyRequestModel.Content));

            CreateMap<UpdatePostRequestModel, UpdatePostCommand>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.UpdatePostBodyRequestModel.Title))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.UpdatePostBodyRequestModel.Content)); ;

            CreateMap<DeletePostRequestModel, DeletePostCommand>();
        }
    }
}
