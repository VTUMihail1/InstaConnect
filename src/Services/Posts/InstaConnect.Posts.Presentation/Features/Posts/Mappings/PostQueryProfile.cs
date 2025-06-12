using AutoMapper;

using InstaConnect.Posts.Application.Features.Posts.Queries.GetAll;
using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Presentation.Features.Posts.Mappings;

internal class PostQueryProfile : Profile
{
    public PostQueryProfile()
    {
        CreateMap<PostPagination, PostQueryPagination>();

        CreateMap<PostRequestSorting, PostQuerySorting>();

        CreateMap<PostRequestPagination, PostQueryPagination>();

        CreateMap<PostPagination, PostQueryPagination>();

        CreateMap<GetAllPostsRequest, GetAllPostsQuery>();

        CreateMap<GetPostByIdRequest, GetPostByIdQuery>();

        CreateMap<GetPostByIdQueryResponse, GetPostByIdResponse>();

        CreateMap<GetAllPostsQueryResponse, GetAllPostsResponse>();
    }
}
