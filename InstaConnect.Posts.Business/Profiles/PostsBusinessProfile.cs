using AutoMapper;
using InstaConnect.Posts.Business.Commands.Posts.AddPost;
using InstaConnect.Posts.Business.Commands.Posts.DeletePost;
using InstaConnect.Posts.Business.Commands.Posts.UpdatePost;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Business.Queries.GetAllFilteredPosts;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Users.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Profiles
{
    public class PostsBusinessProfile : Profile
    {
        public PostsBusinessProfile()
        {
            CreateMap<GetAllFilteredPostsQuery, PostFilteredCollectionQuery>()
                .ConstructUsing(src =>
                     new PostFilteredCollectionQuery
                     {
                         Expression = p => (src.UserId == string.Empty || p.UserId.Equals(src.UserId)) &&
                                           (src.Title == string.Empty || p.Title.Contains(src.Title))
                     });

            CreateMap<AddPostCommand, GetUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<UpdatePostCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<DeletePostCommand, ValidateUserByIdRequest>()
                .ForMember(dest => dest.CurrentUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Post, ValidateUserByIdRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<AddPostCommand, Post>();

            CreateMap<UpdatePostCommand, Post>();

            CreateMap<Post, PostViewDTO>();
        }
    }
}
