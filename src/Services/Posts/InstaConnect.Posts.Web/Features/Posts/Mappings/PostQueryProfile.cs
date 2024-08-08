using AutoMapper;
using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetAllPosts;
using InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;
using InstaConnect.Posts.Web.Features.Posts.Models.Requests;
using InstaConnect.Posts.Web.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Web.Features.Posts.Mappings;

internal class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<GetAllPostsRequest, GetAllPostsQuery>();

        CreateMap<GetPostByIdRequest, GetPostByIdQuery>();

        CreateMap<PostQueryViewModel, PostQueryResponse>();

        CreateMap<PostPaginationQueryViewModel, PostPaginationQueryResponse>();
    }
}
