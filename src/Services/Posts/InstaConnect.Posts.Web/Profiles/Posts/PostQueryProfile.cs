using AutoMapper;
using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;
using InstaConnect.Posts.Business.Queries.Posts.GetPostById;
using InstaConnect.Posts.Read.Web.Models.Requests.Post;
using InstaConnect.Posts.Web.Models.Responses.Posts;

namespace InstaConnect.Posts.Web.Profiles.Posts;

internal class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<GetAllPostsRequest, GetAllPostsQuery>();

        CreateMap<GetAllFilteredPostsRequest, GetAllFilteredPostsQuery>();

        CreateMap<GetPostByIdRequest, GetPostByIdQuery>();

        CreateMap<PostQueryViewModel, PostQueryResponse>();

        CreateMap<PostPaginationQueryViewModel, PostPaginationQueryResponse>();
    }
}
